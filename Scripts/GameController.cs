using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public GameObject PieceBase;
    public Sprite[] PieceFaces;
    public Vector3[] Pos;
    private EfeectController effect;
    

    private List<GameObject> PieceList = new List<GameObject>();
    

    private int[,] puzzle1 = new int[3, 4] //パズルの初期配置
    {
        {7,6,3,2},
        {4,1,0,5},
        {9,8,10,11},
    };

    // Start is called before the first frame update
    void Start()
    {
        SetCorrectPos();
        CreatePieces();
    }
    void CreatePieces()
    {
        for (int i = 0; i < 12; i++)
        {
            var piece = Instantiate(PieceBase);
            piece.GetComponent<SpriteRenderer>().sprite = PieceFaces[i];
            PieceList.Add(piece);
        }
        PieceList[11].SetActive(false);
        Dealing();
    }

    void Dealing() //ピースを並べる関数
    {
        float offsetX = 2.5f; 
        float offsetY = -2.33f; 

        for (int i=0; i<3; i++)
        {
            for(int j=0; j<4; j++)
            {
                if (puzzle1[i, j] == 11)
                {
                    continue;
                }

                PieceList[puzzle1[i,j]].transform.position = new Vector2(offsetX*j, i * offsetY) ;
               
            }
        }
    }

    void SetCorrectPos() //正解の配列をセットする関数
    {
        int n = 0;
        float offsetX = 2.5f;
        float offsetY = -2.33f;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Pos[n] = new Vector2(j * offsetX , i * offsetY);
                n++;
           }
        }


            }

    public void ClearCheck()
    {
        if (PieceList[0].transform.position == Pos[0] 
            && PieceList[1].transform.position == Pos[1]
             && PieceList[2].transform.position == Pos[2]
              && PieceList[3].transform.position == Pos[3]
               && PieceList[4].transform.position == Pos[4]
                && PieceList[5].transform.position == Pos[5]
                 && PieceList[6].transform.position == Pos[6]
                  && PieceList[7].transform.position == Pos[7]
                   && PieceList[8].transform.position == Pos[8]
                    && PieceList[9].transform.position == Pos[9]
                     && PieceList[10].transform.position == Pos[10]
            
        )
        {
            PieceList[11].SetActive(true);
            PieceList[11].transform.position = new Vector2(7.5f,-4.66f);

            MainPlayer mainBGM = FindObjectOfType<MainPlayer>();
            if (mainBGM != null && mainBGM.MainBGM != null)
            {
                Destroy(mainBGM.MainBGM);
            }

            effect = GetComponent<EfeectController>();
            StartCoroutine(PauseAndExecute());
        }
    }

    IEnumerator PauseAndExecute()
    {
        // エフェクトを再生
        effect.judge = true;
        // エフェクトが発生するのを待機
        yield return new WaitForSeconds(1f); // エフェクトを表示しておくための時間

        // シーンを切り替える
        SceneManager.LoadScene("ClearScene");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

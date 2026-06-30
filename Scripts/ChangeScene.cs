using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonDown()
    {
        SceneManager.LoadScene("PuzzleScene");
    }

    public void DetailButtonDown()
    {
        MainPlayer mainBGM = FindObjectOfType<MainPlayer>();
        if (mainBGM != null && mainBGM.MainBGM != null)
        {
            Destroy(mainBGM.MainBGM);
        }
        
        SceneManager.LoadScene("DetailScene");
    }
   public void QuitButtonDown()
    {
        Application.Quit();
    }
}

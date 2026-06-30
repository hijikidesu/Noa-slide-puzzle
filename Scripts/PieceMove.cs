using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMove : MonoBehaviour
{
    private GameController gameControllerCS;
    void PieceMoving()
    {
        //上にrayを飛ばす　飛ばす範囲は要調整
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position + new Vector3(0,1.3f,0), Vector2.up, 0.1f);
        if (!hitUp)
        {
            transform.position += new Vector3(0, 2.33f, 0);
        }

        //下にrayを飛ばす　飛ばす範囲は要調整
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position + new Vector3(0,-1.3f,0), Vector2.down, 0.1f);
        if (!hitDown)
        {
            transform.position -= new Vector3(0, 2.33f, 0);
        }

        //右にrayを飛ばす　飛ばす範囲は要調整
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + new Vector3(1.3f,0,0), Vector2.right, 0.1f);
        if (!hitRight)
        {
            transform.position += new Vector3(2.5f, 0, 0);
        }

        //左にrayを飛ばす　飛ばす範囲は要調整
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + new Vector3(-1.3f,0,0), Vector2.left, 0.1f);
        if (!hitLeft)
        {
            transform.position -= new Vector3(2.5f, 0 , 0);
        }

        gameControllerCS.ClearCheck();
    }

    private void OnMouseDown()
    {
        PieceMoving();
    }


    // Start is called before the first frame update
    void Start()
    {
        gameControllerCS = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public GameObject MainBGM;
    // Start is called before the first frame update
    void Start()
    {
        
        int numMusicPlayers = FindObjectsOfType<MainPlayer>().Length;

        if (numMusicPlayers > 1)
        {
            Destroy(MainBGM);
        }
        else
        {
            DontDestroyOnLoad(MainBGM);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfeectController : MonoBehaviour
{
    public bool judge = false;
 void Update()
    {
        if (judge)
        {
            GetComponent<ParticleSystem>().Play();
            judge = false;
        }
    }

    
}

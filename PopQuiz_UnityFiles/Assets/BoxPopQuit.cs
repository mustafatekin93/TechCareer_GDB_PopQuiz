using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPopQuit : MonoBehaviour
{
    public GameObject pipe;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            pipe.tag = "quitGame";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPup : MonoBehaviour
{
    private Animator anim;
    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Player")
        {
            effect.Play(true);
            anim.SetTrigger("pop");
        }
    }
}

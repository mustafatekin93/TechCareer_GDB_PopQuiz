using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HareketRB : MonoBehaviour
{
    private Rigidbody2D rb2;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb2.AddForce(Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb2.AddForce(Vector2.down * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb2.AddForce(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb2.AddForce(Vector2.right * speed);
        }
    }
}

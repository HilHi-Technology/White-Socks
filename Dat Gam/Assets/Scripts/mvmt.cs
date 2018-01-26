using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvmt : MonoBehaviour {

    public float moveSpeed;
    float x = 0;
    float y = 0;


    Animator anim;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");        //Get user inputs
        y = Input.GetAxis("Vertical");

        if (x != 0 || y != 0)                   //Update Animation
        {
            anim.speed = 1;
            
            anim.SetFloat("Move_Ver", y);
            anim.SetFloat("Move_Hor", x);

            if (y != 0)
            {
                anim.SetBool("Ver?", true);
            }
            else
            {
                anim.SetBool("Ver?", false);
            }
        }
        else
        {
            anim.Play(0);
            anim.speed = 0;
        }

        rb.velocity = new Vector2(x, y);        //Move
    }
}
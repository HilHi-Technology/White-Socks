using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mvmt : MonoBehaviour {

    public float moveSpeed;
    float x = 0;
    float y = 0;

    public static Mvmt instance;

    bool touchingBed;
    bool e;
    bool q;
    public bool dreaming;

    Animator anim;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        instance = this;
    }

  /*  void OnTriggerEnter2D(Collider2D other)
    {
        touchingBed = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        touchingBed = false;
    }
    */
    void Update()
    {
        x = Input.GetAxis("Horizontal");        //Get user inputs
        y = Input.GetAxis("Vertical");
 //       if (Input.GetKeyDown("e")){ e = true; } else{ e = false; }
        if (Input.GetKeyDown("q")) { q = true; } else { q = false; }

//        if (touchingBed && e){ dreaming = true; }
        if (dreaming && q) { dreaming = false; }

        if (x != 0 || y != 0)                   //Update Animation
        {
            anim.speed = 1;
            
            anim.SetFloat("Move_Ver", y);
            anim.SetFloat("Move_Hor", x);
            anim.SetBool("Dreaming", dreaming);

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
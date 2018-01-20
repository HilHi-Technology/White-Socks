using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvmt : MonoBehaviour {

    public float moveSpeed;
    float x = 0;
    float y = 0;

    Rigidbody2D RB;
    Animator anim;

    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();}

    void Update()
    {
        x = Input.GetAxis("Horizontal");        //Get user inputs
        y = Input.GetAxis("Vertical");

        anim.SetFloat("Move_Hor", x);           //Update animations
        anim.SetFloat("Move_Ver", y);

        RB.velocity = new Vector2(x, y);        //Move
    }
}

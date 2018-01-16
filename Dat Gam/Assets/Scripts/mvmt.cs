using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvmt : MonoBehaviour {

    float speed = 1.0f;
    float x = 0;
    float y = 0;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        animator.SetFloat("Move_Hor", x);
        animator.SetFloat("Move_Ver", y);

        var move = new Vector3(x, y, 0);
        transform.position += move * speed * Time.deltaTime;
    }
}

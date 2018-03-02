using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Locked : MonoBehaviour {

    public int locked;

    public Door_Locked instance;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Mvmt.instance.dreaming && collision.tag == "Player")
        {
            anim.SetInteger("Toggled", 1);
            anim.SetTrigger("Hit");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!Mvmt.instance.dreaming && collision.tag == "Player")
        {
            anim.SetInteger("Toggled", -1);
        }
    }

    void Update ()
    {
    }
}

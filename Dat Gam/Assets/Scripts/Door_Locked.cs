using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Locked : MonoBehaviour {

    public int locked;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!Mvmt.instance.dreaming)
        {
            anim.SetInteger("Toggled", 1);
            anim.SetTrigger("Hit");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (!Mvmt.instance.dreaming)
        {
            anim.SetInteger("Toggled", -1);
        }
    }

    void Update ()
    {
    }
}

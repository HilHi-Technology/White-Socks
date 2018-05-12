using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Locked : MonoBehaviour {

    public bool startLocked;
    public int locked;
    public bool impermeable;
    public Door_Locked instance;

    BoxCollider2D coll;
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        instance = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Mvmt.instance.dreaming && (collision.tag == "Player" || collision.tag == "nurse"))
        {
            anim.SetInteger("Toggled", 1);
            anim.SetTrigger("Hit");
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (!Mvmt.instance.dreaming && (collision.tag == "Player" || collision.tag == "nurse"))
        {
            anim.SetInteger("Toggled", -1);
        }
    }

    void Update ()
    {
        if (locked == -1)
        {
            anim.SetInteger("Locked", 1);
            coll.enabled = false;
        }
        else
        {
            if (Mvmt.instance.dreaming && !impermeable)
            {
                coll.enabled = false;
            }
            else
            {
                anim.SetInteger("Locked", -1);
                coll.enabled = true;
            }
        }

        
        /*else
        {
            coll.enabled = true;
        }*/
    }
}

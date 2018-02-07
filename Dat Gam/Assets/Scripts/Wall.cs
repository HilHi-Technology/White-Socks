using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool impermeable;

    Animator anim;
    BoxCollider2D coll;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (Mvmt.instance.dreaming)
        {
            if (!impermeable)
            {
                coll.enabled = false;
            }

            anim.SetInteger("Toggled", 1);
        }
        else
        {
            coll.enabled = true;
            anim.SetInteger("Toggled", -1);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool impermeable;

    bool chanced = false;

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

            if (!chanced)
            {
                /*if (Random.Range(0, 10) == 9)
                {
                    anim.SetTrigger("Chance");
                }
                else
                {*/
                    anim.SetInteger("Toggled", 1);
                //}

                //chanced = true;
            }
        }
        else
        {
            coll.enabled = true;
            anim.SetInteger("Toggled", -1);
            chanced = false;
        }
    }
}
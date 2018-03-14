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

        if (impermeable)
        {
            anim.SetBool("Impermeable", true);
        }
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
                anim.SetInteger("Toggled", 1);

                if (Random.Range(0, 4) == 0)
                {
                    anim.SetTrigger("Chance");
                }
                chanced = true;
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
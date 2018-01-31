using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    Animator anim;
    BoxCollider2D coll;

    void Start()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        if (mvmt.instance.dreaming)
        {
            coll.enabled = false;
            anim.SetInteger("Dreaming", 1);
        }
        else
        {
            coll.enabled = true;
            anim.SetInteger("Dreaming", -1);
        }
    }
}
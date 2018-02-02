﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Unlocked : MonoBehaviour {

    Animator anim;
    BoxCollider2D coll;

    void Start ()
    {
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
	}

    void OnTriggerEnter2D()
    {
        anim.SetInteger("Toggled", 1);
        coll.enabled = false;
    }
    void OnTriggerExit2D()
    {
        anim.SetInteger("Toggled", -1);
        coll.enabled = true;
    }

    void Update ()
    {

    }
}

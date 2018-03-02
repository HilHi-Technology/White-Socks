using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Unlocked : MonoBehaviour {

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!Mvmt.instance.dreaming && collision.tag == "Player")
        {
            anim.SetInteger("Toggled", 1);
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

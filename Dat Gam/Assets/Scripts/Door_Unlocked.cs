using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Unlocked : MonoBehaviour {

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
	}

    void OnTriggerEnter2D()
    {
        if (!Mvmt.instance.dreaming)
        {
            anim.SetInteger("Toggled", 1);
        }
    }
    void OnTriggerExit2D()
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour {

    public int pressed;
    public static Lever instance;
    public int active;

    bool touching;
    bool e;

    Animator anim;

    void Start ()
    {
        anim = GetComponent<Animator>();
        instance = this;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        touching = true;
    }
	void OnTriggerExit2D(Collider2D other)
    {
        touching = false;
    }


	void Update ()
    {
        if (Input.GetKeyDown("e"))
        {
            e = true;
        }
        else
        {
            e = false;
        }

        if (touching && e)
        {
            pressed = -pressed;
            anim.SetInteger("Pressed", pressed);
        }
    }
}

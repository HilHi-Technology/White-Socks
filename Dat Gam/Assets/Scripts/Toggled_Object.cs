using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggled_Object : MonoBehaviour {

    public int active;

    Animator anim;
    BoxCollider2D coll;

	void Start ()
    {
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }
	
	
	void Update ()
    {
        active = Lever.instance.pressed;
 
        anim.SetInteger("Toggled", active);

        if (Mvmt.instance.dreaming)
        {
            coll.enabled = false;
        }
        else
        {
            if (active > 0)
            {
              coll.enabled = false;
            }
            else
            {
                coll.enabled = true;
            }
        }
    }
}

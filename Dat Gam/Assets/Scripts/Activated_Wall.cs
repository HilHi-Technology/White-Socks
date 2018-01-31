using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activated_Wall : MonoBehaviour {

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



        anim.SetInteger("Dreaming", active);



        if (mvmt.instance.dreaming)
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

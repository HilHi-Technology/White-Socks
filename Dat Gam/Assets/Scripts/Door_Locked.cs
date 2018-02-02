using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Locked : MonoBehaviour {

    public int locked;

    Rect textArea = new Rect(10, 5, Screen.width, Screen.height);
    bool lockText;

    Animator anim;
    BoxCollider2D coll;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (locked > 0)
        {
            anim.SetInteger("Toggled", 1);
            coll.enabled = false;
        }
        if (locked < 0)
        {
            lockText = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (locked > 0)
        {
            anim.SetInteger("Toggled", -1);
            coll.enabled = true;
        }

        lockText = false;
    }

    private void OnGUI()
    {
        if (lockText)
        {
            GUI.Label(textArea, "Locked");
        }
        else
        {
            GUI.Label(textArea, "");
        }
    }
    void Update ()
    {
        locked = Lever.instance.pressed;
    }
}

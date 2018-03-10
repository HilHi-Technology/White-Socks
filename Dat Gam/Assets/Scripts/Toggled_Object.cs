using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggled_Object : MonoBehaviour
{

    public int pressed;
    public static Toggled_Object instance;
    public int active;

    public int toggled_when; //0 = anytime, 1 = awake, 2 = asleep

    bool touching;
    bool e;

    public float delay;

    Animator anim;

    void Start()
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

    void TimeWait()
    {
        pressed = -pressed;
        anim.SetInteger("Pressed", pressed);
    }

    void Update()
    {
        if (Input.GetKeyDown("e")) { e = true; } else { e = false; }

        if (touching && e)
        {
            if ((toggled_when == 2 && Mvmt.instance.dreaming) || (toggled_when == 1 && !Mvmt.instance.dreaming) || (toggled_when == 0))
            {
                pressed = -pressed;
                anim.SetInteger("Pressed", pressed);

                if (delay != 0)
                {
                    Invoke("TimeWait", delay);
                }
            }
        }
    }
}

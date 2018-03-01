using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseController : MonoBehaviour {

    public float speed;
    public float errorMargin;

    public List<Vector3> pathway;
    int location = 0;
    int total = 0;
    bool moving = false;
    Transform previous;

    Vector3 target;
    Vector3 place;

    Animator anim;

    void Start ()
    {
        total = pathway.Count;

        anim = GetComponent<Animator>();
    }
	
	void Update ()
    {
        float step = speed * Time.deltaTime;

        previous = transform;

        if (!moving)
        {
            location += 1;
            if (location > total - 1) { location = 0; }
            target = pathway[location];

            moving = true;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Mathf.Abs(transform.position.x - target.x) < errorMargin && Mathf.Abs(transform.position.y - target.y) < errorMargin)
            {
                moving = false;
            }
        }
        
        float y = Mathf.Sign(transform.position.y - previous.position.y);
        float x = Mathf.Sign(transform.position.x - previous.position.x);

        if (y != 0) { anim.SetBool("ver?", true); } else { anim.SetBool("ver?", false); }
        anim.SetInteger("x", Mathf.RoundToInt(x));
        anim.SetInteger("y", Mathf.RoundToInt(y));

    }
}

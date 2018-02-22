using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseController : MonoBehaviour {

    public float speed;

    public List<Vector3> pathway;
    int location = 0;
    int total = 0;
    bool moving = false;

    bool hit = false;

    Vector3 target;
    Vector3 place;

    void Start ()
    {
        total = pathway.Count;
    }
	
	void Update ()
    {
        if (!moving)
        {
            location += 1;
            if (location > total - 1)
            {
                location = 0;
            }

            target = pathway[location];
            moving = true;
            hit = false;
        }
        else
        {
            while (!hit)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed);

                if (transform.position == target)
                {
                    hit = true;
                    moving = false;
                }
            }
        }
	}
}

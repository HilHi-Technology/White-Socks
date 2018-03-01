using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseController : MonoBehaviour {

    public float speed;
    public float range;
    public float errorMargin;

    public List<Vector3> pathway;
    int location = 0;
    int total = 0;

    float x;
    float y;

    RaycastHit hit = new RaycastHit();

    Vector3 target;
    GameObject player;
    Animator anim;

    void Start ()
    {
        total = pathway.Count;
        target = pathway[1];
        anim = GetComponent<Animator>();
        player = GameObject.Find("Bob (Player)");
    }

	void Update ()
    {
        move();
        updateAnim();
        

    }

    void move()
    {
        float step = speed * Time.deltaTime;

        if (Mathf.Abs(transform.position.x - target.x) < errorMargin && Mathf.Abs(transform.position.y - target.y) < errorMargin)
        {
            location += 1;
            if (location > total - 1) { location = 0; }
            target = pathway[location];
        }  

        Vector3 to = player.transform.position;
        Vector3 direction = to - transform.position;
        if (Physics.Raycast(transform.position, direction, range) && hit.transform.tag == "Player")
        {
            Debug.Log("hit");
            target = player.transform.position;
        }
        else
        {
            target = pathway[location];
        }

        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    void updateAnim()
    {
        y = Mathf.Sign(target.y - transform.position.y);
        x = Mathf.Sign(target.x - transform.position.x);

        if (Mathf.Abs(target.y - transform.position.y) < Mathf.Abs(target.x - transform.position.x)) { y = 0; }

        if (y != 0) { anim.SetBool("ver?", true); } else { anim.SetBool("ver?", false); }
        anim.SetInteger("x", Mathf.RoundToInt(x));
        anim.SetInteger("y", Mathf.RoundToInt(y));
    }
}

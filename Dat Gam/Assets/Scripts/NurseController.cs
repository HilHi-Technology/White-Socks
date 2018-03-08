using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NurseController : MonoBehaviour {

    public float speed;
    public float range;
    public float errorMargin;
    public Object room;
    public List<Vector3> pathway;
    int location = 0;
    int total = 0;
    bool ver;
    float x;
    float y;
    bool sighted;
    
    Vector3 target;
    GameObject player;
    Animator anim;
    Transform coll;
    CircleCollider2D hit;

    void Start ()
    {
        total = pathway.Count;
        target = pathway[1];
        anim = GetComponent<Animator>();
        player = GameObject.Find("Bob (Player)");
        coll = GameObject.Find("Nurse_coll").GetComponent<Transform>();
    }

    void Update ()
    {
        move();
        updateAnim();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Vector3.Distance(player.transform.position, transform.position) < .3)
            {
                if (Mvmt.instance.dreaming)
                {
                    Mvmt.instance.awaken();
                }
                else
                {
                    SceneManager.LoadScene(room.name);
                }
            }
        }
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
        if (!NurseCollider.instance.sighted) { target = pathway[location]; } else { target = player.transform.position; }

        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    void updateAnim()
    {
        y = Mathf.Sign(target.y - transform.position.y);
        x = Mathf.Sign(target.x - transform.position.x);

        if (Mathf.Abs(target.y - transform.position.y) < Mathf.Abs(target.x - transform.position.x)) { y = 0; ver = false; } else { ver = true; }

        anim.SetBool("ver?", ver);
        anim.SetInteger("x", Mathf.RoundToInt(x));
        anim.SetInteger("y", Mathf.RoundToInt(y));
        if (ver)
        {
            if (y == 1) { coll.rotation = Quaternion.Euler(0, 0, 180); }
            if (y == -1) { coll.rotation = Quaternion.Euler(0, 0, 0); }
        }
        else
        {
            if (x == 1) { coll.rotation = Quaternion.Euler(0, 0, 90); }
            if (x == -1) { coll.rotation = Quaternion.Euler(0, 0, 270); }
        }

        if (Mvmt.instance.dreaming) { anim.SetBool("Dreaming", true); } else { anim.SetBool("Dreaming", false); }
    }
}

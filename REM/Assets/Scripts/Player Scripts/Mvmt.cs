using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mvmt : MonoBehaviour {

    public bool cheats;

    public float moveSpeed;
    float speed;

    float x = 0;
    float y = 0;

    public static Mvmt instance;
    
    bool q;
    public bool dreaming;
    public Vector3 awake;

    public GameObject sleep;
    Animator anim;
    Rigidbody2D rb;

    public List<GameObject> floor;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        instance = this;
        speed = moveSpeed;
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");        //Get user inputs
        y = Input.GetAxis("Vertical");
        if (Input.GetKeyDown("q")) { q = true; } else { q = false; }

        if (cheats) { cheat(); }

        if (dreaming && q)
        {
            awaken();
        }

        if (x != 0 || y != 0)                   //Update Animation
        {
            anim.speed = 1;

            anim.SetFloat("Move_Ver", y);
            anim.SetFloat("Move_Hor", x);

            if (y != 0)
            {
                anim.SetBool("Ver?", true);
            }
            else
            {
                anim.SetBool("Ver?", false);
            }
        }
        else
        {
            anim.Play(0);
            anim.speed = 0;
        }

        anim.SetBool("Dreaming", dreaming);

        if (dreaming)
        {
            for (int j = 0; j < floor.Count; j++)
            {
                floor[j].GetComponent<Animator>().SetInteger("Toggled", 1);
            }
        }

        rb.velocity = new Vector2(x * speed, y * speed);        //Move
    }

    public void awaken()
    {
        dreaming = false;
        transform.position = awake;

        anim.speed = 1;
        anim.SetBool("Dreaming", dreaming);
        anim.speed = 0;

        for (int j = 0; j < floor.Count; j++)
        {
            floor[j].GetComponent<Animator>().SetInteger("Toggled", -1);
        }

        Destroy(sleep);
    }

    private void cheat()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { speed = 2; } else { speed = moveSpeed; }

        if (Input.GetKeyDown("n")) { GameObject.Find("BlackScreen").GetComponent<Fader>().fadeIn(1); }
        if (Input.GetKeyDown("m")) { GameObject.Find("BlackScreen").GetComponent<Fader>().fadeOut(1); }

        if (Input.GetKeyDown("b")) { dreaming = true; awake = transform.position; }
    }
}
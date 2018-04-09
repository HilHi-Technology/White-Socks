using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {

    bool e;

    bool touching;
    
    public GameObject sleeping;
    public GameObject sleep;

    Animator playerAnim;
    Vector3 location;

	void Start ()
    {
        location = transform.position;
        playerAnim = Mvmt.instance.GetComponent<Animator>();
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
		if (Input.GetKeyDown("e")) { e = true; } else { e = false; }

        if (touching && e && !Mvmt.instance.dreaming)
        {
            //GameObject.Find("BlackScreen").GetComponent<Fader>().fadeInOut(2);
            Mvmt.instance.sleep = Instantiate(sleeping, transform.position, transform.rotation);

            playerAnim.speed = 1;
            playerAnim.SetBool("Dreaming", true);
            playerAnim.speed = 0;

            Mvmt.instance.dreaming = true;
            Mvmt.instance.awake = location;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {

    bool e;
    bool q;

    bool touching;

    public GameObject sleeping;
    GameObject sleep;

    Vector3 location;

	void Start ()
    {
        location = transform.position;
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
        if (Input.GetKeyDown("q")) { q = true; } else { q = false; }

        if (touching && e)
        {
            if (!Mvmt.instance.dreaming)
            {
                sleep = Instantiate(sleeping, transform.position, transform.rotation);
            }

            Mvmt.instance.dreaming = true;
            Mvmt.instance.awake = location;
        }
        if (q)
        {
            Destroy(sleep);
        }
	}
}

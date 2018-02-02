using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour {

    bool e;
    bool touching;

	void Start ()
    {

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

        if (touching && e) { Mvmt.instance.dreaming = true; }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurseCollider : MonoBehaviour {

    public static NurseCollider instance;
    public bool sighted;

	void Start ()
    {
		instance = this;
	}
	
	void Update ()
    {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sighted = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sighted = false;
        }
    }
}

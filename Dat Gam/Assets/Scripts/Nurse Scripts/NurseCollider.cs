using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NurseCollider : MonoBehaviour {

    public static NurseCollider instance;
    public bool sighted;

    public Object room;

    PolygonCollider2D polyColl;
    CapsuleCollider2D capsColl;

    void Start ()
    {
		instance = this;

        polyColl = GetComponent<PolygonCollider2D>();
        capsColl = GetComponent<CapsuleCollider2D>();
	}
	
	void Update ()
    {
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sighted = true;
            polyColl.enabled = false;
            capsColl.enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sighted = false;
            capsColl.enabled = false;
            polyColl.enabled = true;
        }
    }
}

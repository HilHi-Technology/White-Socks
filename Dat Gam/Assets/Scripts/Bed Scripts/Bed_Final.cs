using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed_Final : MonoBehaviour {

    bool e;
    bool touching;

    public GameObject sleeping;

    void Start()
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

    void nextRoom()
    {
        //new WaitUntil((() => GameObject.Find("BlackScreen").GetComponent<Fader>().fadeIn(2)));

        ClipboardController.instance.play = true;
    }

    void Update()
    {
        if (Input.GetKeyDown("e")) { e = true; } else { e = false; }

        if (touching && e && !Mvmt.instance.dreaming)
        {
            Instantiate(sleeping, transform.position, transform.rotation);
            GameObject.Find("Bob (Player)").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Bob (Player)").GetComponent<Mvmt>().enabled = false;

            Invoke("nextRoom", 0.3f);
        }
    }
}

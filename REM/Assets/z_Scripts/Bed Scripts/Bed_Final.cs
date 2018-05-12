using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed_Final : MonoBehaviour {
    
    bool touching;
    public GameObject sleeping;
    public GameObject clipboard;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bob (Player)")
        {
            touching = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Bob (Player)")
        {
            touching = false;
        }
    }

    void nextRoom()
    {
        //new WaitUntil((() => GameObject.Find("BlackScreen").GetComponent<Fader>().fadeIn(2)));

        ClipboardController.instance.play = true;
    }

    void Update()
    {
        if (touching && Input.GetKeyDown("e") && !Mvmt.instance.dreaming)
        {
            GameObject bob = GameObject.Find("Bob (Player)");
            Instantiate(sleeping, transform.position, transform.rotation);
            bob.GetComponent<SpriteRenderer>().enabled = false;
            bob.GetComponent<Mvmt>().enabled = false;
            bob.GetComponent<Rigidbody2D>().velocity = new Vector2 (0, 0);

            Invoke("nextRoom", 0.3f);
        }
    }
}

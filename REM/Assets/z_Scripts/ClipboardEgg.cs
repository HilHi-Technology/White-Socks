using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardEgg : MonoBehaviour {
    
    bool touching;
    bool next = false;
    bool pressed = false;

    int i = 0;
    public List<string> messages;

    void Start ()
    {
    }

    void OnTriggerEnter2D(Collider2D other) { touching = true; }
    void OnTriggerExit2D(Collider2D other) { touching = false; }

    void Update ()
    {
		if (touching && Input.GetKeyDown("e") && !pressed)
        {
            i = 0;
            pressed = true;
        }

        if (pressed)
        {
            printMessages();
        }
	}

    private void printMessages()
    {
        next = TextBox.instance.print(messages[i]);

        if (next)
        {
            i++;
        }
        if (i >= messages.Count)
        {
            pressed = false;
        }
    }
}

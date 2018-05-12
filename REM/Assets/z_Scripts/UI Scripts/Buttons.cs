using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public ClipboardController clipboard;
    public Text text;
    Image image;
    Button button;

    void Start()
    {
        text.GetComponent<Text>().enabled = false;
        image = GetComponent<Image>();
        button = GetComponent<Button>();
    }

    void Update ()
    {
		if (clipboard.turnOn)
        {
            text.GetComponent<Text>().enabled = true;
            image.enabled = true;
            button.enabled = true;
        }
        else
        {
        text.GetComponent<Text>().enabled = false;
        image.enabled = false;
        button.enabled = false;
        }
	}
}

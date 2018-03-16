using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipboardTest : MonoBehaviour {

    public Image faderImage;
    public bool fade;
    public float fadeAmount = 5f;
    Color c;
    /*
	void Start ()
    {
        fade = false;
        c = faderImage.color;
	}
	
	void Update ()
    {
		if (fade)
        {
            fadeIn();
        }
        else
        {
            fadeOut();
        }
	}

    public void fadeIn()
    {
        Debug.Log(c.a);
        if(faderImage.material.color.a < 255)
        {
            c.a += fadeAmount;
            faderImage.color = c;
        }
        else
        {
            fade = false;
        }
    }
    public void fadeOut()
    {
        if (faderImage.material.color.a > 0)
        {
            c.a -= fadeAmount;
            faderImage.color = c;
        }
    }*/
}

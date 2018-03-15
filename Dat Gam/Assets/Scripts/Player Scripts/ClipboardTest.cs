using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClipboardTest : MonoBehaviour {

    public Image faderImage;
    public bool fade;
    public float fadeAmount = 5f;
    
	void Start ()
    {
        fade = false;
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
        if(faderImage.material.color.a < 255)
        {
            Color c = faderImage.color;
            c.a += fadeAmount * Time.deltaTime;
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
            Color c = faderImage.color;
            c.a -= fadeAmount * Time.deltaTime;
            faderImage.color = c;
        }
    }
}

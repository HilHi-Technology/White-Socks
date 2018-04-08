using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClipboardController : MonoBehaviour {

    public Object nextRoom;

    Animator anim;
    SpriteRenderer sprite;
    
    public static ClipboardController instance;

    public bool play = false;
    bool animStarted = false;
    public bool animEnded = false;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        instance = this;
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
        if (play)
        {
            if (playAnim())
            {
                SceneManager.LoadScene(nextRoom.name);
            }
        }
	}

    public bool playAnim()
    {
        if (!animStarted)
        {
            //GameObject.Find("Tutorial").GetComponent<Tutorial>().clearScreen();
            sprite.enabled = true;
            anim.enabled = true;
            anim.SetTrigger("playAnim");
            animStarted = true;
        }
        if (animEnded)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void animEnd()
    {
        animEnded = true;
    }
}

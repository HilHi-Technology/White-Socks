using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClipboardController : MonoBehaviour {
    
    public int nextRoom;

    Animator anim;
    Image sprite;
    public Text clipboardText;
    public static ClipboardController instance;
    bool enterKey;
    public bool play = false;
    bool animStarted = false;
    public bool animEnded = false;

	void Start ()
    {
        sprite = GetComponent<Image>();
        sprite.enabled = false;
        instance = this;
        anim = GetComponent<Animator>();
        clipboardText.text = "";
    }

	void Update ()
    {
        enterKey = (Input.GetKeyDown(KeyCode.Return));

        if (play)
        {
            if (playAnim())
            {
                if (nextRoom != -1)
                {
                    if (print("Level completed!\n\n\n\n<enter to continue>"))
                    {
                        changeToScene(nextRoom);
                    }
                }
                else
                {
                    print("You win!");
                }
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

    private bool print(string message)
    {
        clipboardText.text = message;
        if (enterKey)
        {
            enterKey = false;
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

    public void changeToScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}

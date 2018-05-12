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
    bool escapeKey;
    public bool play = false;
    bool animStarted = false;
    public bool animEnded = false;

    public bool turnOn = false;

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
        enterKey = Input.GetKeyDown(KeyCode.Return);
        if (Input.GetKeyDown(KeyCode.Escape)) { escapeKey = true; }

        if (play)
        {
            if (playAnim())
            {
                turnOn = true;
                print("Level completed!");
            }
        }

        if (escapeKey)
        {
            bool end = ExitLevel();
            if (end)
            {
                changeToScene(0);
            }
        }
	}

    public bool playAnim()
    {
        if (!animStarted)
        {
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

    private void print(string message)
    {
        clipboardText.text = message;
    }

    private bool ExitLevel()
    {
        TextBox.instance.print("Press 'enter' to return to main menu\npress '\\' to cancel");
        if (Input.GetKeyDown(KeyCode.Return))
        {
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            enterKey = false;
            return false;
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
        if (scene == -1)
        {
            scene = nextRoom;
        }
        SceneManager.LoadScene(scene);
    }
}

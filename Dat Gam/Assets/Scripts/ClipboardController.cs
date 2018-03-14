using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClipboardController : MonoBehaviour {

    public Object nextRoom;

    Animator anim;
    Animation animate;
    SpriteRenderer sprite;
    GameObject blackScreen;

    public bool playAnim = false;
    public static ClipboardController instance;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        instance = this;
        anim = GetComponent<Animator>();
        anim.speed = 0;
        blackScreen = GameObject.Find("Black");
    }

	void Update ()
    {
		if (playAnim)
        {
            StartCoroutine(play());

            playAnim = false;
        }
	}

    IEnumerator play()
    {
        sprite.enabled = true;
        anim.Play(0);
        anim.speed = 1;

        while (animate["Clipboard_Flip"].normalizedTime != 1f)
        {
            yield return null;
        }

        FadeToBlack(0.05f);

        SceneManager.LoadScene(nextRoom.name);
    }

    public void FadeFromBlack(float rate)
    {
        Debug.Log("strted");
        float opacity = 0;
        while (opacity != 1)
        {
            blackScreen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
            opacity += rate;

            if (rate > 1f) { rate = 1f; }
        }
    }
    public void FadeToBlack(float rate)
    {
        float opacity = 1;
        while (opacity != 0)
        {
            blackScreen.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
            opacity -= rate;

            if (rate < 0f) { rate = 0f; }
        }
    }
}

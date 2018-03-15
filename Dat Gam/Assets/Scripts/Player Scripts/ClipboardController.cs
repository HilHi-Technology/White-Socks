using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClipboardController : MonoBehaviour {

    public Object nextRoom;

    Animator anim;
    SpriteRenderer sprite;
    SpriteRenderer blackScreen;

    public bool playAnim = false;
    public static ClipboardController instance;

        float fadeDir = -1.0f;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        instance = this;
        anim = GetComponent<Animator>();
        anim.speed = 0;
        blackScreen = GameObject.Find("BlackScreen").GetComponent<SpriteRenderer>();
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

        //while (anim["Clipboard_Flip"].normalizedTime != 1f)
        //{
        //    yield return null;
        //}

        FadeToBlack(0.05f);

        SceneManager.LoadScene(nextRoom.name);

        yield return null;
    }


    public void FadeToBlack(float rate)
    {
        blackScreen.enabled = true;
        blackScreen.color = new Color(1f, 1f, 1f, 0f);

        float opacity = 0;
        while (opacity < 1)
        {
            //opacity += rate * Time.deltaTime;
            opacity += 1f * rate * Time.deltaTime;
            opacity = Mathf.Clamp01(opacity);
            blackScreen.color = new Color(1f, 1f, 1f, opacity);
        }

        blackScreen.color = new Color(1f, 1f, 1f, 1f);
    }
    public void FadeFromBlack(float rate)
    {
        blackScreen.enabled = true;
        blackScreen.color = new Color(1f, 1f, 1f, 1f);

        float opacity = 1;
        while (opacity > 0)
        {
            //opacity -= rate * Time.deltaTime;
            opacity += -1f * rate * Time.deltaTime;
            opacity = Mathf.Clamp01(opacity);

            blackScreen.color = new Color(1f, 1f, 1f, opacity);
        }

        blackScreen.color = new Color(1f, 1f, 1f, 0f);
        blackScreen.enabled = false;
    }

    /*void OnGUI()
    {

            opacity += fadeDir * rate * Time.deltaTime;
            opacity = Mathf.Clamp01(alpha);

            GUI.color.a = alpha;

            GUI.depth = drawDepth;

            GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }*/
}

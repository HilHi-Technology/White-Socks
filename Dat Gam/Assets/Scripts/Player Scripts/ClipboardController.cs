using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClipboardController : MonoBehaviour {

    public Object nextRoom;

    Animator anim;
    SpriteRenderer sprite;
    
    public static ClipboardController instance;

    float fadeDir = -1.0f;

	void Start ()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
        instance = this;
        anim = GetComponent<Animator>();
    }

	void Update ()
    {
	}

    public void playAnim()
    {
        //sprite.enabled = true;
        //anim.SetTrigger("playAnim");

        //new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        SceneManager.LoadScene(nextRoom.name);
    }
    /*
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
    }*/
}

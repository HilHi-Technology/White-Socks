using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour {

    public bool fadeEnded = true;
    
    bool inEnded = false;
    bool outEnded = false;

    Image image;
    Animator anim;

	void Start ()
    {
        image = GetComponent<Image>();
        anim = GetComponent<Animator>();
        anim.speed = 0;
	}

    void Update()
    {
        
    }

    public bool fadeIn(float speed)
    {
        anim.SetTrigger("In");
        anim.speed = speed;

        new WaitUntil((() => inEnded));
        inEnded = false;
        return true;

    }
    public bool fadeOut(float speed)
    {
        anim.SetTrigger("Out");
        anim.speed = speed;

        new WaitUntil((() => outEnded));
        outEnded = false;
        return true;
    }
    public IEnumerator fadeInOut(float speed)
    {
        //fadeIn(2);
        yield return new WaitUntil((() => fadeIn(2)));
        //fadeOut(2);
        yield return new WaitUntil((() => fadeOut(2)));
        yield return true;
    }

    public void inEnd()
    {
        inEnded = true;
    }
    public void outEnd()
    {
        outEnded = true;
    }
}

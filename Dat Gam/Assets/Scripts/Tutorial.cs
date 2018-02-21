using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {


    public bool start;       bool started = false;
    public bool lever1;      bool lever1ed = false;
    public bool bed;         bool beded = false;
    public bool dreaming;    bool dreamed = false;
    public bool lever2;      bool lever2ed = false;
    public bool end;         bool ended = false;

    bool e;

    string text;
    
    public static Tutorial instance;

    public GameObject lever_1;
    public GameObject lever_2;

	void Start ()
    {
        instance = this;

        start = true;
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text);
    }

    void Update ()
    {
        if (lever_1.GetComponent<Toggled_Object>().pressed > 0) { bed = true; }
        if (lever_2.GetComponent<Toggled_Object>().pressed > 0) { end = true; }

        if (Input.GetKeyDown("return")) { e = true; } else { e = false; }

        if (start && !started)
        {
            text = "Press WASD to move <enter to continue>";

            if (e)
            {
                text = "";
                started = true;
                lever1 = true;
                e = false;
            }
        }

        if (lever1 && !lever1ed)
        {
            text = "Move to the lever and press [e] <enter to continue>";

            if (e)
            {
                text = "";
                lever1ed = true;
                e = false;
            }
        }

        if (bed && !beded)
        {
            text = "Move to the bed and press [e] to go to sleep <enter to continue>";

            if (e)
            {
                text = "";
                beded = true;
                e = false;
            }
        }

        if (dreaming && !dreamed)
        {
            text = "Now that you're asleep, you can walk through some walls! <enter to continue>";

            if (e)
            {
                text = "";
                dreamed = true;
                e = false;
                lever2 = true;
            }
        }

        if (lever2 && !lever2ed)
        {
            text = "Now you can get to the other lever, and activate it <enter to continue>";

            if (e)
            {
                text = "";
                lever2ed = true;
                e = false;
            }
        }

        if (end && !ended)
        {
            text = "Now press [q] to wake up, and you can walk to the [end object] to beat the level! <enter to continue>";

            if (e)
            {
                text = "";
                ended = true;
                e = false;
            }
        }
	}
}

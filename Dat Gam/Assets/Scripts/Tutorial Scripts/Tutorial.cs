using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    Image image;

    public bool enterKey;

    public Text tutorialText;

    bool move = true;               bool move_true = false;
    bool lever1 = false;            bool lever1_true = false;
    public bool bed = false;        bool bed_true = false;
    public bool lever2 = false;     bool lever2_true = false;
    bool lever2p2 = false;          bool lever2p2_true = false;
    public bool end = false;        bool end_true = false;

	void Start ()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        tutorialText.text = "";

    }
	
	void Update ()
    {
        enterKey = (Input.GetKeyDown(KeyCode.Return));

        if (move && !move_true)
        {
            image.enabled = true;
            tutorialText.text = "Use the WASD keys to move \n <enter to continue> ";
            if (enterPressed())
            {
                clearScreen();
                move_true = true;
                enterKey = false;
                lever1 = true;
            }
        }

        if (lever1 && !lever1_true)
        {
            image.enabled = true;
            tutorialText.text = "Move to the lever, and press 'e' \n <enter to continue> ";
            if (enterPressed())
            {
                clearScreen();
                lever1_true = true;
            }
        }

        if (bed && !bed_true)
        {
            image.enabled = true;
            tutorialText.text = "Now you can go through the door, and get to the bed. Press 'e' on the bed to sleep \n <enter to continue> ";
            if (enterPressed())
            {
                clearScreen();
                bed_true = true;
            }
        }

        if (lever2 && !lever2_true)
        {
            image.enabled = true;
            tutorialText.text = "Now that you're asleep, you're dreaming! This allows you to walk through walls\n <enter to continue> ";
            if (enterPressed())
            {
                clearScreen();
                lever2p2 = true;
                lever2_true = true;
                enterKey = false;
            }
        }

        if (lever2p2 && !lever2p2_true)
        {
            image.enabled = true;
            tutorialText.text = "Maybe now you can reach the other lever \n <enter to continue> ";
            if (enterPressed())
            {
                clearScreen();
                lever2p2_true = true;
            }
        }

        if (end && !end_true)
        {
            image.enabled = true;
            tutorialText.text = "Now the door's open. Press 'q' to wake up, and you can sleep in the end bed \n <enter to continue> ";
            if (enterPressed())
            {
                clearScreen();
                end_true = true;
            }
        }
    }

    private bool enterPressed()
    {
        if (enterKey == false)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void clearScreen()
    {
        image.enabled = false;
        tutorialText.text = "";
    }
}

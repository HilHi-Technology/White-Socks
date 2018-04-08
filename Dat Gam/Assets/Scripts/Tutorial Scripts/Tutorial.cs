using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

    Image image;
    public int level;
    public bool enterKey;

    public Text tutorialText;

    //level = 1
    bool move = true;               bool move_true = false;
    bool lever1 = false;            bool lever1_true = false;
    public bool bed = false;        bool bed_true = false;
    public bool lever2 = false;     bool lever2_true = false;
    bool lever2p2 = false;          bool lever2p2_true = false;
    public bool end = false;        bool end_true = false;

    //level = 2
    bool nurse = true;              bool nurse_true = false;
    bool nurse2 = false;            bool nurse2_true = false;
    public bool monster = false;    bool monster_true = false;

	void Start ()
    {
        image = GetComponent<Image>();
        image.enabled = false;
        tutorialText.text = "";
    }
	
	void Update ()
    {
        enterKey = (Input.GetKeyDown(KeyCode.Return));

        if (level == 1)
        {
            if (move && !move_true)
            {
                bool end = print("Use the WASD keys to move \n <enter to continue> ");
                if (end) { move_true = true; lever1 = true; }
            }

            if (lever1 && !lever1_true)
            {
                bool end = print("Move to the lever, and press 'e' \n <enter to continue> ");
                if (end) { lever1_true = true; }
            }

            if (bed && !bed_true)
            {
                bool end = print("Now you can go through the door, and get to the bed. Press 'e' on the bed to sleep \n <enter to continue> ");
                if (end) { bed_true = true; }
            }

            if (lever2 && !lever2_true)
            {
                bool end = print("Now that you're asleep, you're dreaming! This allows you to walk through walls\n <enter to continue> ");
                if (end) { lever2p2 = true; lever2_true = true; }
            }

            if (lever2p2 && !lever2p2_true)
            {
                bool end = print("Maybe now you can reach the other lever \n <enter to continue> ");
                if (end) { lever2p2_true = true; }
            }

            if (end && !end_true)
            {
                bool end = print("Now the door's open. Press 'q' to wake up, and you can sleep in the end bed \n <enter to continue> ");
                if (end) { end_true = true; }
            }
        }

        if (level == 2)
        {
            if (nurse && !nurse_true)
            {
                bool end = print("Do you hear that? Sounds like footsteps \n <enter to continue>");
                if (end) { nurse_true = true; nurse2 = true; }
            }
            if (nurse2 && !nurse2_true)
            {
                bool end = print("Maybe they put a guard on this hallway. Better be careful this time \n <enter to continue>");
                if (end) { nurse2_true = true; }
            }
            if (monster && !monster_true)
            {
                bool end = print("Did you hear that snarl? There must be a monster in this dream \n <enter to continue>");
                if (end) { monster_true = true; }
            }
        }
    }

    private bool print(string message)
    {
        image.enabled = true;
        tutorialText.text = message;
        if (enterKey)
        {
            clearScreen();
            enterKey = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void clearScreen()
    {
        image.enabled = false;
        tutorialText.text = "";
    }
}

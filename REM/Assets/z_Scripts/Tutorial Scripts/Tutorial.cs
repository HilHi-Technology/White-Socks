using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    
    public int level;
    private TextBox text;

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
        text = TextBox.instance;
    }
	
	void Update ()
    {

        if (level == 1)
        {
            if (move && !move_true)
            {
                bool end = text.print("Use the WASD keys to move \n ***Press enter when you have finished reading***");
                if (end) { move_true = true; lever1 = true; end = false; }
            }

            if (lever1 && !lever1_true)
            {
                bool end = text.print("Move to the lever, and press 'e' \n <enter to continue> ");
                if (end) { lever1_true = true; end = false; }
            }

            if (bed && !bed_true)
            {
                bool end = text.print("Now you can go through the door, and get to the bed. Press 'e' on the bed to sleep \n <enter to continue> ");
                if (end) { bed_true = true; end = false; }
            }

            if (lever2 && !lever2_true)
            {
                bool end = text.print("Now that you're asleep, you're dreaming! This allows you to walk through most walls\n <enter to continue> ");
                if (end) { lever2p2 = true; lever2_true = true; end = false; }
            }

            if (lever2p2 && !lever2p2_true)
            {
                bool end = text.print("Maybe now you can reach the other lever \n <enter to continue> ");
                if (end) { lever2p2_true = true; end = false; }
            }

            if (end && !end_true)
            {
                bool end = text.print("Now the door's open. Press 'q' to wake up, and you can sleep in the end bed \n <enter to continue> ");
                if (end) { end_true = true; end = false; }
            }
        }

        if (level == 2)
        {
            if (nurse && !nurse_true)
            {
                bool end = text.print("Do you hear that? Sounds like footsteps \n <enter to continue>");
                if (end) { nurse_true = true; nurse2 = true; end = false; }
            }
            if (nurse2 && !nurse2_true)
            {
                bool end = text.print("Maybe they put a guard on this hallway. Better be careful this time \n <enter to continue>");
                if (end) { nurse2_true = true; end = false; }
            }
            if (monster && !monster_true)
            {
                bool end = text.print("Did you hear that snarl? There must be a monster in this dream \n <enter to continue>");
                if (end) { monster_true = true; end = false; }
            }
        }
    }
}

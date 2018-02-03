using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    //Call class of door and switches
    public List<ActivateDoor> activators;
    public KeyCode InteractKey = KeyCode.E;

    void Start()
    {
        for (int i = 0; i < activators.Count; i++)
        {
            activators[i].activatedSwitches = new Dictionary<string, bool>();
        }
    }

    void Update()
    {
        //Loop through the activators

        for (int i = 0; i < activators.Count; i++)
        {
            //If our switches are all activated
            if (activators[i].activatedSwitches.Count == activators[i].switches.Count)
                //Loop through the activated switches in the current activator element
                for (int j = 0; j < activators[i].activatedSwitches.Count; j++)
                {
                    //Then loop through all the switches
                    for (int k = 0; k < activators[i].switches.Count; k++)
                    {
                        //We double check to see if our switches are true
                        if (activators[i].activatedSwitches[activators[i].switches[k].gameObject.name] == true)
                        {
                            //And if they are then activate our door.
                            //Instead of having this here you can switch it to do something else for your
                            //door
                            if (activators[i].switches[j].GetComponent<Lever>().pressed > 0)
                            {
                                activators[i].door.GetComponent<Animator>().SetInteger("Toggled", 1);
                                activators[i].door.GetComponent<Collider2D>().enabled = false;
                            }

                            else
                            {
                                activators[i].door.GetComponent<Animator>().SetInteger("Toggled", -1);
                                activators[i].door.GetComponent<Collider2D>().enabled = true;
                            }
                        }
                    }
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Go through each activator created in the editor
        for (int i = 0; i < activators.Count; i++)
        {
            //Go through each switch in each element of the activators
            for (int j = 0; j < activators[i].switches.Count; j++)
            {
                //If the other object that we interacted with is one of our switches
                //and our list does not already have it then set it
                //as activated. Meaning add it to the activatedSwitches list.
                if (other.gameObject == activators[i].switches[j]
                    && !(activators[i].activatedSwitches.ContainsKey(activators[i].switches[j].name)))
                {
                    Debug.Log("Activate Switch!");
                    //We add the activated switch to the activator containing it and set it to true.
                    activators[i].activatedSwitches.Add(activators[i].switches[j].name, true);
                }
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        //Go through each activator created in the editor
        for (int i = 0; i < activators.Count; i++)
        {
            //Go through each switch in each element of the activators
            for (int j = 0; j < activators[i].switches.Count; j++)
            {
                //If the other object that we interacted with is one of our switches
                //and our list does not already have it then set it
                //as activated. Meaning add it to the activatedSwitches list.
                if (other.gameObject == activators[i].switches[j]
                    && !(activators[i].activatedSwitches.ContainsKey(activators[i].switches[j].gameObject.name)))
                {
                    //We add the activated switch to the activator containing it and set it to true.
                    activators[i].activatedSwitches.Add(activators[i].switches[j].name, false);
                    Debug.Log("De-activated Switch!");
                }
            }
        }
    }
}

[System.Serializable]
public class ActivateDoor
{
    [Header("Doors")]
    public GameObject door;

    //The switches now use the Lever script to access some of its components
    [Header("Switches")]
    public List<GameObject> switches;
    
    [Header("Activated Switches")]
    public Dictionary<string, bool> activatedSwitches;
}
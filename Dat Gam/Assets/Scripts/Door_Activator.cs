using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Activator : MonoBehaviour
{
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
            //If switches are all activated
            if (activators[i].activatedSwitches.Count == activators[i].switches.Count)
            {
                //Loop through the activated switches in the current activator element
                for (int j = 0; j < activators[i].activatedSwitches.Count; j++)
                {
                    //Then loop through all the switches
                    for (int k = 0; k < activators[i].switches.Count; k++)
                    {
                        //We double check to see if our switches are true
                        if (activators[i].activatedSwitches[activators[i].switches[k].gameObject.name] == true)
                        {
                            //And if they are then activate door.
                            if (activators[i].switches[j].GetComponent<Toggled_Object>().pressed > 0)
                            {
                                activators[i].door.GetComponent<Animator>().SetInteger("Locked", 1);
                                activators[i].door.GetComponent<Collider2D>().enabled = false;
                            }

                            else
                            {
                                activators[i].door.GetComponent<Animator>().SetInteger("Locked", -1);
                                activators[i].door.GetComponent<Collider2D>().enabled = true;
                            }

                        }
                    }
                }
            }
            if (Mvmt.instance.dreaming)
            {
                if (!activators[i].impermeable)
                {
                    activators[i].door.GetComponent<Collider2D>().enabled = false;
                }

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Go through each activator
        for (int i = 0; i < activators.Count; i++)
        {
            //Go through each switch in each element of the activators
            for (int j = 0; j < activators[i].switches.Count; j++)
            {
                //If the collided object is a switch and the list does not already have it then add it to the activatedSwitches list.
                if (other.gameObject == activators[i].switches[j]
                    && !(activators[i].activatedSwitches.ContainsKey(activators[i].switches[j].name)))
                {
                    //Add the activated switch to the activator containing it and set it to true.
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
                //If the collided object is a switch and the list does not already have it then add it to the activatedSwitches list.
                if (other.gameObject == activators[i].switches[j]
                    && !(activators[i].activatedSwitches.ContainsKey(activators[i].switches[j].gameObject.name)))
                {
                    //Add the activated switch to the activator containing it and set it to true.
                    activators[i].activatedSwitches.Add(activators[i].switches[j].name, false);
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
    public bool impermeable;

    [Header("Switches")]
    public List<GameObject> switches;
    
    [Header("Activated Switches")]
    public Dictionary<string, bool> activatedSwitches;
}
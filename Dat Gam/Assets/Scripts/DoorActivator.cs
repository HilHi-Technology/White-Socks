using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    public List<ActivateDoor> activators;

    //
    public int locked;

    Animator anim;
    BoxCollider2D coll;
    //

    void Start()
    {
        for (int i = 0; i < activators.Count; i++)
        {
            activators[i].activatedSwitches = new Dictionary<string, bool>();
        }

        //
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
        //

    }

    void Update()
    {
        for (int i = 0; i < activators.Count; i++)
        {
            if (activators[i].activatedSwitches.Count == activators[i].switches.Count)
                for (int j = 0; j < activators[i].activatedSwitches.Count; j++)
                {
                    for (int k = 0; k < activators[i].switches.Count; k++)
                    {
                        if (activators[i].activatedSwitches[activators[i].switches[k].name] == true)
                        {
                            //activators[i].door.SetActive(true);
                            
                            locked = -1;
                        }
                        else
                        {
                            locked = 1;
                        }
                    }
                }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        for (int i = 0; i < activators.Count; i++)
        {
            for (int j = 0; j < activators[i].switches.Count; j++)
            {
                if (other.gameObject == activators[i].switches[j]
                    && !(activators[i].activatedSwitches.ContainsKey(activators[i].switches[j].name)))
                {
                    activators[i].activatedSwitches.Add(activators[i].switches[j].name, true);
                }
            }
        }
        */
        
        if (locked > 0)
        {
            anim.SetInteger("Toggled", 1);
            coll.enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (locked > 0)
        {
            anim.SetInteger("Toggled", -1);
            coll.enabled = true;
        }
    }
}


[System.Serializable]
public class ActivateDoor
{
    [Header("Doors")]
    public GameObject door;

    [Header("Switches")]
    public List<GameObject> switches;

    [Header("Activated switches")]
    public Dictionary<string, bool> activatedSwitches;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Tut : MonoBehaviour {

    public int bed;

	void Update ()
    {
        if (bed == 1)
           {
            if (GameObject.Find("Bob (Player)").GetComponent<Mvmt>().dreaming)
            {
                GameObject.Find("Tutorial").GetComponent<Tutorial>().lever2 = true;
            }
        }
        
        if (bed == 2)
        {
            if (GameObject.Find("Bob (Player)").GetComponent<Mvmt>().dreaming)
            {
                GameObject.Find("Tutorial").GetComponent<Tutorial>().monster = true;
            }
        }
    }
}

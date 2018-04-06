using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed_Tut : MonoBehaviour {


	void Update ()
    {
        if (GameObject.Find("Bob (Player)").GetComponent<Mvmt>().dreaming)
        {
            GameObject.Find("Tutorial").GetComponent<Tutorial>().lever2 = true;
        }
    }
}

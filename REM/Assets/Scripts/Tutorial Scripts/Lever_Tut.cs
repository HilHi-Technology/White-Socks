using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_Tut : MonoBehaviour {

    public int lever;

	void Update ()
    {
        if (lever == 1)
        {
            if (GetComponent<Toggled_Object>().pressed > 0)
            {
                GameObject.Find("Tutorial").GetComponent<Tutorial>().bed = true;
            }
        }
        if (lever == 2)
        {
            if (GetComponent<Toggled_Object>().pressed > 0)
            {
                GameObject.Find("Tutorial").GetComponent<Tutorial>().end = true;
            }
        }
	}
}

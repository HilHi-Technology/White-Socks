using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever2_Tut : MonoBehaviour {

    void Update()
    {
        if (GetComponent<Toggled_Object>().pressed > 0)
        {
            GameObject.Find("Tutorial").GetComponent<Tutorial>().end = true;
        }
    }
}

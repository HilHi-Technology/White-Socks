using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour {

    bool esc;
    int paused = -1;


	void Start ()
    {
		
	}
	
	void Update ()
    {
		esc = Input.GetKeyDown(KeyCode.Escape);

        if (esc)
        {
            paused = -paused;
            Debug.Log("pause");
            Debug.Log(paused);
        }

        if (paused > 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
	}
}

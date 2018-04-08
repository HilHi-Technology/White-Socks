using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClipboardAnim : MonoBehaviour {

    public void animEnd()
    {
        GameObject.Find("Clipboard").GetComponent<ClipboardController>().animEnded = true;
    }
}

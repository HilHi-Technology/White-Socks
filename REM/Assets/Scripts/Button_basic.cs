using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_basic : MonoBehaviour {

    /*public Object nextScene;

    public void loadScene()
    {
        SceneManager.LoadScene(nextScene.name);
    }*/

    public void OnGUI()
    {
        if (GUI.Button(new Rect(10, 70, 50, 30), "Start"))
            SceneManager.LoadScene("_Start Menu (Level Select)");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleControllerScript : MonoBehaviour {

    public void changeToScene(int scene)
    {
        if (scene == -2)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
    }
}

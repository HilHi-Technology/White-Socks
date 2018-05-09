using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBox : MonoBehaviour {

    public static TextBox instance;

    private Image image;
    public Text text;

    bool enter;

    private void Start()
    {
        instance = this;
        image = GetComponent<Image>();
        image.enabled = false;
    }

    private void Update()
    {
        enter = Input.GetKeyDown(KeyCode.Return);
    }

    public bool print(string message)
    {
        image.enabled = true;
        text.text = message;

        if(enter)
        {
            image.enabled = false;
            text.text = "";
            enter = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}

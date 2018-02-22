using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

    //bool changed = false;
    public List<Color> colors;

    //Camera cam;

	void Start ()
    {
        offset = transform.position - player.transform.position;
        //cam = GetComponent<Camera>();
    }
	
	void LateUpdate ()
    {
        transform.position = player.transform.position + offset;

        /*if (Mvmt.instance.dreaming)
        {
            if (!changed)
            {
                cam.backgroundColor = colors[Random.Range(0,colors.Count)];
                changed = true;
            }
        }
        else
        {
            cam.backgroundColor = Color.gray;
            changed = false;
        }*/
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomB : MonoBehaviour
{
    public Camera cam;

    private void Start()
    {
        GameController.instance.SetToolTipText("Perceive how different projections have effect in how the image looks closer to a real world scenario.");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam.orthographic = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam.orthographic = false;
        }
    }

    private void OnDisable()
    {
        cam.orthographic = false;
    }
}

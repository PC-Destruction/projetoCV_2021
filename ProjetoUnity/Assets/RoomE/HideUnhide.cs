using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideUnhide : MonoBehaviour
{

    public GameObject sphere, wireframe_sphere;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            if (sphere.GetComponent<Renderer>().enabled)
            {
                sphere.GetComponent<Renderer>().enabled = false;
                wireframe_sphere.GetComponent<Renderer>().enabled = true;
                GameController.instance.SetToolTipText("Wireframe mode let's you see better the different levels of detail");

            }
            else
            {
                sphere.GetComponent<Renderer>().enabled = true;
                wireframe_sphere.GetComponent<Renderer>().enabled = false;

            }
        }


    }
}

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


        if (Input.GetKeyDown("1"))
        {
            GameController.instance.SetToolTipText("This is the Highest Level of detail this sphere mesh has, try other levels to see how it changes");
        }

        if (Input.GetKeyDown("2"))
        {
            GameController.instance.SetToolTipText("This is the Second Highest Level of detail this sphere mesh has, try other levels to see how it changes");
        }

        if (Input.GetKeyDown("3"))
        {
            GameController.instance.SetToolTipText("This is the Second Lowest Level of detail this sphere mesh has, try other levels to see how it changes");
        }

        if (Input.GetKeyDown("4"))
        {
            GameController.instance.SetToolTipText("This is the Lowest Level of detail this sphere mesh has, try other levels to see how it changes");
        }

    }
}

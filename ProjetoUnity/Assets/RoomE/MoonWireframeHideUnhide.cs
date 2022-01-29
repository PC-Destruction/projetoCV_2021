using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonWireframeHideUnhide : MonoBehaviour
{
    public GameObject moon, wireframe_moon;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            if (Input.GetKeyDown("w"))
            {
                if (moon.GetComponent<Renderer>().enabled)
                {
                    moon.GetComponent<Renderer>().enabled = false;
                    wireframe_moon.GetComponent<Renderer>().enabled = true;

                }
                else
                {
                    moon.GetComponent<Renderer>().enabled = true;
                    wireframe_moon.GetComponent<Renderer>().enabled = false;

                }
            }
        }
    }
}

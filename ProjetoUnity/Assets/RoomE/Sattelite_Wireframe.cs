using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sattelite_Wireframe : MonoBehaviour
{
    public GameObject sattelite, wireframe_sattelite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            if (sattelite.GetComponent<Renderer>().enabled)
            {
                sattelite.GetComponent<Renderer>().enabled = false;
                wireframe_sattelite.GetComponent<Renderer>().enabled = true;

            }
            else
            {
                sattelite.GetComponent<Renderer>().enabled = true;
                wireframe_sattelite.GetComponent<Renderer>().enabled = false;

            }
        }

    }
}

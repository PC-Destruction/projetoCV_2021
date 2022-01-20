using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trocarshading : MonoBehaviour
{
    public Material flat;
    public Material gouraud;
    public Material phong;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1)) { 

            GetComponent<MeshRenderer>().material = flat;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<MeshRenderer>().material = gouraud;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<MeshRenderer>().material = phong;
        }

    }
}

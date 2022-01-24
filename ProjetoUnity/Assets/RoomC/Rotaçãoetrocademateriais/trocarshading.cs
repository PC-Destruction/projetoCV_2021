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
            GameController.instance.SetToolTipText("The lighting is evaluated only once for each polygon.");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetComponent<MeshRenderer>().material = gouraud;
            GameController.instance.SetToolTipText("The illumination model to each vertex is calculated the light intensity from the vertex normal.");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GetComponent<MeshRenderer>().material = phong;
            GameController.instance.SetToolTipText("The light intensities the normals are interpolated between the vertices.");
        }

    }
}

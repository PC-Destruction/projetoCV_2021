using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODMesh_Controller : MonoBehaviour
{
    
    public Mesh VHD, HD, MD, LD;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up* 0.2f);

        if (Input.GetKeyDown("1"))
        {
            GetComponent<MeshFilter>().mesh = VHD;
            GameController.instance.SetToolTipText("This is the Highest Level of detail this sphere mesh has, try other levels to see how it changes");
        }

        if (Input.GetKeyDown("2"))
        {
            GetComponent<MeshFilter>().mesh = HD;
            GameController.instance.SetToolTipText("This is the Second Highest Level of detail this sphere mesh has, try other levels to see how it changes");
        }

        if (Input.GetKeyDown("3"))
        {
            GetComponent<MeshFilter>().mesh = MD;
            GameController.instance.SetToolTipText("This is the Second Lowest Level of detail this sphere mesh has, try other levels to see how it changes");
        }

        if (Input.GetKeyDown("4"))
        {
            GetComponent<MeshFilter>().mesh = LD;
            GameController.instance.SetToolTipText("This is the Lowest Level of detail this sphere mesh has, try other levels to see how it changes");
        }
        
    }
}

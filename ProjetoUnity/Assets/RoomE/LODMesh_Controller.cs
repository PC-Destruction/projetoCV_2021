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
        }

        if (Input.GetKeyDown("2"))
        {
            GetComponent<MeshFilter>().mesh = HD;
        }

        if (Input.GetKeyDown("3"))
        {
            GetComponent<MeshFilter>().mesh = MD;
        }

        if (Input.GetKeyDown("4"))
        {
            GetComponent<MeshFilter>().mesh = LD;
        }
        
    }
}

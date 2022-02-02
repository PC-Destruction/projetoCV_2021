using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RunTimeShaders : MonoBehaviour
{
    public GameObject Light;

    private void Start()
    {
        
        Light = GameObject.Find("luz");
    }

    
    void Update () {
         
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Vector4 converted = new Vector4(Light.transform.position.x-transform.position.x , Light.transform.position.y- transform.position.y,Light.transform.position.z - transform.position.z,1);
        mr.sharedMaterial.SetVector("_LightPos", converted);
    }
}

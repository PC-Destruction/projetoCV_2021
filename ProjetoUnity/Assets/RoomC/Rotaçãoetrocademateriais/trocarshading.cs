using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trocarshading : MonoBehaviour
{
    public Material flat;
    public Material gouraud;
    public Material phong;
    public GameObject ball;
    public GameObject ball2;
    public GameObject ball3;

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1)) {

            ball.GetComponent<MeshRenderer>().material = flat;
            ball2.GetComponent<MeshRenderer>().material = flat;
            ball3.GetComponent<MeshRenderer>().material = flat;
            GameController.instance.SetToolTipText("The lighting is evaluated only once for each polygon.");
            AudioController.instance.PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ball.GetComponent<MeshRenderer>().material = gouraud;
            ball2.GetComponent<MeshRenderer>().material = gouraud;
            ball3.GetComponent<MeshRenderer>().material = gouraud;
            GameController.instance.SetToolTipText("The illumination model to each vertex is calculated the light intensity from the vertex normal.");
            AudioController.instance.PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ball.GetComponent<MeshRenderer>().material = phong;
            ball2.GetComponent<MeshRenderer>().material = phong;
            ball3.GetComponent<MeshRenderer>().material = phong;
            AudioController.instance.PlaySound();
            GameController.instance.SetToolTipText("The light intensities the normals are interpolated between the vertices.");
        }

    }
}

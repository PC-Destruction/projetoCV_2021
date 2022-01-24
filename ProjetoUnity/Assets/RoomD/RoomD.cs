using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomD : MonoBehaviour
{
    public Material no_height_material;
    public Material height_material;
    public GameObject cube;

    void Start()
    {
        cube.GetComponent<MeshRenderer>().material = no_height_material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            cube.GetComponent<MeshRenderer>().material = no_height_material;
            GameController.instance.SetToolTipText("Without the height map applied this wall looks very bland and fake.");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cube.GetComponent<MeshRenderer>().material = height_material;
            GameController.instance.SetToolTipText("With the height map applied this wall looks much more realistic with all the bumps.");
        }
    }
}

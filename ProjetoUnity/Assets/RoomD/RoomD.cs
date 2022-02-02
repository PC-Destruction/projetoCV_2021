using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomD : MonoBehaviour
{
    public Material no_height_material;
    public Material height_material;
    public Material height_normal_material;
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
            AudioController.instance.PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cube.GetComponent<MeshRenderer>().material = height_material;
            GameController.instance.SetToolTipText("With the normal map applied this wall looks more realistic with all the bumps with no added cost with the geometry.");
            AudioController.instance.PlaySound();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cube.GetComponent<MeshRenderer>().material = height_normal_material;
            GameController.instance.SetToolTipText("With the normal map and the height map applied this wall looks more realistic with all the bumps with no added cost with the geometry.");
            AudioController.instance.PlaySound();
        }
    }
}

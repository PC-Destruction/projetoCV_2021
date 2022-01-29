using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public GameObject centerobject;
    public int rotationvalue = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centerobject.transform.position, new Vector3(0, 1, 0), rotationvalue * Time.deltaTime);
        
    }
}

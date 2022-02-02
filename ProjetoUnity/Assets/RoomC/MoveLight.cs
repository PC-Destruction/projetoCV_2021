using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLight : MonoBehaviour
{
    public Transform[] positions = new Transform[4];

    private int index;

    void Start()
    {
        transform.position = positions[0].position;
        index = 1;

    }

    void Update()
    {
        if (Vector3.Distance(transform.position, positions[index].position) > 0.5)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[index].position, 1 * Time.deltaTime);
        }
        else {
            index = (index + 1) % positions.Length;
        }


    }

}

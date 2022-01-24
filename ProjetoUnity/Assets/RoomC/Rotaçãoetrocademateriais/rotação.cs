using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotação : MonoBehaviour { 
    public float angulo;
    void Update()
    {
        transform.Rotate(0, 0, angulo);
    }
}

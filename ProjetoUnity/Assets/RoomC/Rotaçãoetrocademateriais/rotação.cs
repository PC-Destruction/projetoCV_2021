using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotação : MonoBehaviour { 

    public float angulo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

   // angulo += 1 * Time.deltaTime;
    transform.Rotate(0, 0, angulo);

    }
}

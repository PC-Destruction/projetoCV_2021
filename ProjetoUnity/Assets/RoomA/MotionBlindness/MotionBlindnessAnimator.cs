using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionBlindnessAnimator : MonoBehaviour
{
    public Texture2D[] frames;
    // Start is called before the first frame update
    private MeshRenderer mr;
    void Start()
    {
        mr = this.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int index  = (int)(Time.time * 30); 
        index = index % frames.Length;
        mr.material.mainTexture = frames[index];
    }
}

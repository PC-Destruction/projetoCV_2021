using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomA : MonoBehaviour
{
    public GameObject thatcherPrefab;
    public Transform thatcherPos;
    public Transform thatcherRotatedPos;
    private GameObject thatcherObj;

    private string currentDisplay;

    private GameObject objToLerp;
    private Quaternion lerpDestination;
    void Start()
    {
        
    }

    private void ThatcherEffect()
    {
        if (currentDisplay == "thatcher") {
            objToLerp = thatcherObj;
            lerpDestination = thatcherRotatedPos.rotation;
        } else
        {
            thatcherObj = Instantiate(thatcherPrefab, thatcherPos.position,thatcherPos.rotation);
        }
        currentDisplay = "thatcher";
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ThatcherEffect();
        }

        if (objToLerp != null)
        {
            objToLerp.transform.rotation = Quaternion.Lerp(objToLerp.transform.rotation, lerpDestination, Time.deltaTime * 2.0f);

            if (Quaternion.Angle(objToLerp.transform.rotation, lerpDestination) < 0.1f)
            {
                objToLerp = null;
            }
        }
    }
}

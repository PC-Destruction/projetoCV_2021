using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomA : MonoBehaviour
{
    public GameObject thatcherPrefab;
    public Transform thatcherPos;
    public Transform thatcherRotatedPos;
    private GameObject thatcherObj;

    public GameObject colorPerceptionPrefab;
    private GameObject colorPerceptionObj;

    private string currentDisplay;

    private GameObject objToLerp;
    private Quaternion lerpDestination;
    public Light roomLight;
    void Start()
    {
        
    }

    private void ThatcherEffect()
    {
        roomLight.intensity = 7.5f;
        if (currentDisplay == "thatcher") {
            objToLerp = thatcherObj;
            lerpDestination = thatcherRotatedPos.rotation;
        } else
        {
            Destroy(colorPerceptionObj);
            thatcherObj = Instantiate(thatcherPrefab, thatcherPos.position,thatcherPos.rotation);
        }
        currentDisplay = "thatcher";
    }

    private void ColorPerception()
    {
        Destroy(thatcherObj);
        if (currentDisplay != "ColorPerception")
        {
            roomLight.intensity = 1f;
            currentDisplay = "ColorPerception";
        } else
        {
            colorPerceptionObj = Instantiate(colorPerceptionPrefab);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ThatcherEffect();
        } else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ColorPerception();
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

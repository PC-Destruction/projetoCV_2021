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

    public GameObject gestaltPrefab;
    private GameObject gestaltObj;

    public GameObject motionBlindnessPrefab;
    private GameObject motionBlindnessObj;

    private void ThatcherEffect()
    {
        roomLight.intensity = 7.5f;
        if (currentDisplay == "thatcher") {
            objToLerp = thatcherObj;
            lerpDestination = thatcherRotatedPos.rotation;
        } else
        {
            Destroy(colorPerceptionObj);
            Destroy(gestaltObj);
            Destroy(motionBlindnessObj);
            thatcherObj = Instantiate(thatcherPrefab, thatcherPos.position,thatcherPos.rotation);
        }
        currentDisplay = "thatcher";
    }

    private void ColorPerception()
    {
        Destroy(thatcherObj);
        Destroy(gestaltObj);
        Destroy(motionBlindnessObj);
        if (currentDisplay != "ColorPerception")
        {
            roomLight.intensity = 1f;
            currentDisplay = "ColorPerception";
        } else if (colorPerceptionObj == null)
        {
            colorPerceptionObj = Instantiate(colorPerceptionPrefab);
        }
    }

    public void Gestalt()
    {
        roomLight.intensity = 7.5f;
        Destroy(thatcherObj);
        Destroy(colorPerceptionObj);
        Destroy(motionBlindnessObj);
        if (currentDisplay != "gestalt")
        {
            currentDisplay = "gestalt";
            gestaltObj = Instantiate(gestaltPrefab);
        }
    }

    public void MotionBlindness()
    {
        roomLight.intensity = 7.5f;
        Destroy(thatcherObj);
        Destroy(colorPerceptionObj);
        Destroy(gestaltObj);
        if (currentDisplay != "MotionBlindness")
        {
            currentDisplay = "MotionBlindness";
            motionBlindnessObj = Instantiate(motionBlindnessPrefab);
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
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Gestalt();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MotionBlindness();
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

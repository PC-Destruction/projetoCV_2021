using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float stepInterval;
    public float lastStep;
    public Transform hallPos;
    public Transform roomAPos;
    public Transform roomBPos;
    public Transform roomCPos;
    public Transform roomDPos;
    public Transform roomEPos;
    private string currentRoom;
    private bool inMovement;
    private Queue<Goal> goalQueue;
    private Goal goal;
    private MonoBehaviour current_room_behaviour;

    public Text controlsText;
    public Text toolTipText;

    public static GameController instance;
    private class Goal
    {
        public Vector3 position;
        public Vector3 rotation;

        public Goal(Vector3 pos,Vector3 rot)
        {
            this.position = pos;
            this.rotation = rot;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        } else
        {
            instance = this;
        }
    }

    void Start()
    {
        transform.position = hallPos.position;
        goalQueue = new();
        currentRoom = "H";
        controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom C - <b>C</b>\nRoom D - <b>D</b>\nRoom E - <b>E</b>";
        toolTipText.gameObject.SetActive(false);
        lastStep = stepInterval;
    }

    private void GoToHall()
    {
        goalQueue.Enqueue(new Goal(new Vector3(transform.position.x, transform.position.y, hallPos.position.z),transform.rotation.eulerAngles));
    }

    private void MoveToRoom(string room)
    {
        if (currentRoom != room && !inMovement)
        {
            if (currentRoom != "H")
            {
                GoToHall();
                controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom C - <b>C</b>\nRoom D - <b>D</b>\nRoom E - <b>E</b>";
                toolTipText.gameObject.SetActive(false);
                if (!(current_room_behaviour is null))
                {
                    current_room_behaviour.enabled = false;
                }
                current_room_behaviour = null;
            }
            Vector3 nextPosition = hallPos.position;
            Vector3 nextRotation = hallPos.eulerAngles;
            switch (room)
            {
                case "A":
                    {
                        nextPosition = roomAPos.position;
                        nextRotation = roomAPos.eulerAngles;
                        controlsText.text = "Room B - <b>B</b>\nRoom C - <b>C</b>\nRoom D - <b>D</b>\nRoom E - <b>E</b>\nHall - <b>H</b>\n\n<b>Room Controls:</b>\nThatcher Effect - <b>1</b>(Twice)\nColor Perception - <b>2</b>(Twice)\nGestalt - <b>3</b>\nMotion Blindness - <b>4</b>\n";
                        
                        if (!(current_room_behaviour is null)){
                            current_room_behaviour.enabled = false;
                        }
                        current_room_behaviour = GetComponent<RoomA>();
                        current_room_behaviour.enabled = true;
                        break;
                    }
                case "B":
                    {
                        nextPosition = roomBPos.position;
                        nextRotation = roomBPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom C - <b>C</b>\nRoom D - <b>D</b>\nRoom E - <b>E</b>\nHall - <b>H</b>\n\n<b>Room Controls:</b>\nOrthographic Projection - <b>1</b>\nPrespective Projection - <b>2</b>";
                        if (!(current_room_behaviour is null))
                        {
                            current_room_behaviour.enabled = false;
                        }
                        current_room_behaviour = GetComponent<RoomB>();
                        current_room_behaviour.enabled = true;
                        break;
                    }
                case "C":
                    {
                        nextPosition = roomCPos.position;
                        nextRotation = roomCPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom D - <b>D</b>\nRoom E - <b>E</b>\nHall - <b>H</b>\n\n<b>Room Controls:</b>\nFlat Illumination - <b>1</b>\nGouraud Illumination - <b>2</b>\nPhong Illumination - <b>3</b>";
                        if (!(current_room_behaviour is null))
                        {
                            current_room_behaviour.enabled = false;
                        }
                        current_room_behaviour = GetComponent<trocarshading>();
                        current_room_behaviour.enabled = true;
                        break;
                    }
                case "D":
                    {
                        nextPosition = roomDPos.position;
                        nextRotation = roomDPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom C - <b>C</b>\nRoom E - <b>E</b>\nHall - <b>H</b>\n\n<b>Room Controls:</b>\nWithout Height Map - <b>1</b>\nWith Normal Map - <b>2</b>\nWith Normal Map and Height Map - <b>3</b>\n";
                        if (!(current_room_behaviour is null))
                        {
                            current_room_behaviour.enabled = false;
                        }
                        current_room_behaviour = GetComponent<RoomD>();
                        current_room_behaviour.enabled = true;
                        break;
                    }
                case "E":
                    {
                        nextPosition = roomEPos.position;
                        nextRotation = roomEPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom C - <b>C</b>\nRoom D - <b>D</b>\nHall - <b>H</b>\n\n<b>Room Controls:</b>\nChange LOD - <b>1,2,3,4</b>\nDes/Activate wireframe - <b>W</b>";
                        if (!(current_room_behaviour is null))
                        {
                            current_room_behaviour.enabled = false;
                        }
                        current_room_behaviour = GetComponent<HideUnhide>();
                        current_room_behaviour.enabled = true;
                        break;
                    }
            }
            goalQueue.Enqueue(new Goal(new Vector3(nextPosition.x, nextPosition.y, hallPos.position.z),transform.eulerAngles));
            goalQueue.Enqueue(new Goal(nextPosition,nextRotation));
            currentRoom = room;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveToRoom("A");
            AudioController.instance.PlaySound();
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            MoveToRoom("B");
            AudioController.instance.PlaySound();
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            MoveToRoom("C");
            AudioController.instance.PlaySound();
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToRoom("D");
            AudioController.instance.PlaySound();
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            MoveToRoom("E");
            AudioController.instance.PlaySound();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            MoveToRoom("H");
            AudioController.instance.PlaySound();
        }

        if (inMovement)
        {
            lastStep -= Time.deltaTime;
            if (lastStep < 0 && Vector3.Distance(transform.position, goal.position) > 2.0f)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(goal.position.x, goal.position.y - 3f, goal.position.z), Time.deltaTime * 1.0f);
                if (lastStep < -0.2f)
                {
                    lastStep = stepInterval;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, goal.position, Time.deltaTime * 1.0f);
            }

            Vector3 currentAngle = new Vector3(
             Mathf.LerpAngle(transform.eulerAngles.x, goal.rotation.x, Time.deltaTime * 2.0f),
             Mathf.LerpAngle(transform.eulerAngles.y, goal.rotation.y, Time.deltaTime * 2.0f),
             Mathf.LerpAngle(transform.eulerAngles.z, goal.rotation.z, Time.deltaTime * 2.0f));

            transform.eulerAngles = currentAngle;

            if (Vector3.Distance(transform.position, goal.position) < 0.1f && Vector3.Distance(transform.eulerAngles,goal.rotation) < 0.1f)
            {
                inMovement = false;
            }
        } else if (goalQueue.Count > 0)
        {
            goal = goalQueue.Dequeue();
            inMovement = true;
        }
    }

    public void SetToolTipText(string text)
    {
        toolTipText.gameObject.SetActive(true);
        toolTipText.text = "<b>Tip:</b> " + text;
    }
}

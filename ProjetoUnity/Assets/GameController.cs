using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
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
                        break;
                    }
                case "B":
                    {
                        nextPosition = roomBPos.position;
                        nextRotation = roomBPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom C - <b>C</b>\nRoom D - <b>D</b>\nRoom E - <b>E</b>\nHall - <b>H</b>";
                        break;
                    }
                case "C":
                    {
                        nextPosition = roomCPos.position;
                        nextRotation = roomCPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom D - <b>D</b>\nRoom E - <b>E</b>\nHall - <b>H</b>";
                        break;
                    }
                case "D":
                    {
                        nextPosition = roomDPos.position;
                        nextRotation = roomDPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom C - <b>C</b>\nRoom E - <b>E</b>\nHall - <b>H</b>\n\n<b>Room Controls:</b>\nWithout Height Map - <b>1</b>\nWith Height Map - <b>2</b>\n";
                        break;
                    }
                case "E":
                    {
                        nextPosition = roomEPos.position;
                        nextRotation = roomEPos.eulerAngles;
                        controlsText.text = "Room A - <b>A</b>\nRoom B - <b>B</b>\nRoom C - <b>C</b>\nRoom D - <b>D</b>\nHall - <b>H</b>\n\n<b>Room Controls:</b>\nChange LOD - <b>1,2,3,4</b>\nDes/Activate wireframe - <b>W</b>";
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
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            MoveToRoom("B");
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            MoveToRoom("C");
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveToRoom("D");
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            MoveToRoom("E");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            MoveToRoom("H");
        }

        if (inMovement)
        {
            transform.position = Vector3.Lerp(transform.position, goal.position, Time.deltaTime * 2.0f);

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

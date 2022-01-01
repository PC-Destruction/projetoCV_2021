using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        transform.position = hallPos.position;
        goalQueue = new();
        currentRoom = "H";
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
            }
            Vector3 nextPosition = hallPos.position;
            Vector3 nextRotation = hallPos.eulerAngles;
            switch (room)
            {
                case "A":
                    {
                        nextPosition = roomAPos.position;
                        nextRotation = roomAPos.eulerAngles;
                        break;
                    }
                case "B":
                    {
                        nextPosition = roomBPos.position;
                        nextRotation = roomBPos.eulerAngles;
                        break;
                    }
                case "C":
                    {
                        nextPosition = roomCPos.position;
                        nextRotation = roomCPos.eulerAngles;
                        break;
                    }
                case "D":
                    {
                        nextPosition = roomDPos.position;
                        nextRotation = roomDPos.eulerAngles;
                        break;
                    }
                case "E":
                    {
                        nextPosition = roomEPos.position;
                        nextRotation = roomEPos.eulerAngles;
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
}

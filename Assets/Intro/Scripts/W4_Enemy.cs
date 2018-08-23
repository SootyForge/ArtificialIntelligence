using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class W4_Enemy : MonoBehaviour
{
    // Declaration
    public enum State
    {
        Patrol = 0,
        Seek = 1
    }

    public State currentState = State.Patrol;
    public NavMeshAgent agent;
    public Transform target;
    public float seekRadius = 5f;

    public Transform waypointParent;
    public float moveSpeed;
    public float stoppingDistance = 1f;

    // Creates a collection of Transforms
    private Transform[] waypoints;
    private int currentIndex = 1;

    // CTRL + M + O (Fold Code)
    // CTRL + M + P (UnFold Code)

    void Patrol()
    {
        Transform point = waypoints[currentIndex];

        float distance = Vector3.Distance(transform.position, point.position);
        if (distance < .5f)
        {
            // currentIndex = currentIndex + 1
            currentIndex++;
            if (currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }
        agent.SetDestination(point.position);


        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget < seekRadius)
        {
            currentState = State.Seek;
        }
    }

    void Seek()
    {
        agent.SetDestination(target.position);
        float distToTarget = Vector3.Distance(transform.position, target.position);
        if (distToTarget > seekRadius)
        {
            currentState = State.Patrol;
        }
    }

    // Use this for initialization
    void Start()
    {

        // Getting children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Switch current state
        switch (currentState) //swi - Tab 2x , type 'currentState', then down arrow.
        {
            case State.Patrol:
                // Patrol state
                Patrol();
                break;
            case State.Seek:
                // Seek state
                Seek();
                break;
            default:
                break;
        }
            // If we are in Patrol
                // Call Patrol()
            // If we are in Seek
                // Call Seek()
    }
}

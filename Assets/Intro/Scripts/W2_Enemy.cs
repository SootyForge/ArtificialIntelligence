using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2_Enemy : MonoBehaviour
{
    public Transform waypointParent;

    // Creates a collection of Transforms
    private Transform[] waypoints;
    private int currentIndex = 1;

    // Use this for initialization
    void Start()
    {
        // Getting children of waypointParent
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform point = waypoints[currentIndex];
        float distance = Vector3.Distance(transform.position, point.position);
        if(distance < .5f)
        {
            // currentIndex = currentIndex + 1
            currentIndex++;
            if(currentIndex >= waypoints.Length)
            {
                currentIndex = 1;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, point.position, 0.1f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// CTRL + K + D (Cleans code)
public class W1_Enemy : MonoBehaviour
{
    // camelCasing - Variables
    // PascalCasing - Functions & Class Names
    public NavMeshAgent agent;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }
}

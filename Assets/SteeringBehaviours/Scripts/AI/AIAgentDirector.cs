using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SteeringBehaviours
{
    public class AIAgentDirector : MonoBehaviour
    {
        public AIAgent agent;

        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled
        void FixedUpdate()
        {
            Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(camRay, out hit, 1000f))
            {
                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    agent.SetTarget(hit.point);
                }
            }
        }
    }
}
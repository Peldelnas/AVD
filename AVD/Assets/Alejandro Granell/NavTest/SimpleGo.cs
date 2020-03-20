using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimpleGo : MonoBehaviour
{
    // Start is called before the first frame update
    NavMeshAgent agent;
    public Transform Destination;
    Vector3 previousPosition;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = Destination.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Destination.transform.position != previousPosition)
        {
            agent.destination = Destination.transform.position;
            previousPosition = Destination.transform.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//注释
public class NavMeshVehicle : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        agent.SetDestination(destination.position);
    }
}
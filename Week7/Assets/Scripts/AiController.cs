using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AiController : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform start;
    public Transform target; 
    CapsuleCollider capsule;

    [Range(0, 100)] public float speed;
    [Range(1, 500)] public float walkRadius;

    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = speed;
            agent.SetDestination(RandomNavMeshLocation());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (agent != null && agent.remainingDistance <= agent.stoppingDistance)
        {
            agent.SetDestination(RandomNavMeshLocation());
        }
    
    }
    
    public Vector3 RandomNavMeshLocation()
    {
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        Vector3 finalPosition = Vector3.zero;
        randomPosition += transform.position;
        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }

        return finalPosition;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveForkLift : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Transform _destination;
    [SerializeField] private float _threshold = 0.5f;
    

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(_agent.transform.position, _destination.position) > _threshold)
        {
            _agent.SetDestination(_destination.position);
        }
    }
}

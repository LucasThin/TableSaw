using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AI;

public class GuideController : MonoBehaviour
{
    [SerializeField] AvatarMovement avatarMovement;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private float _threshold = 0.5f;
    [SerializeField] private GuidePath _guidePath;
    
    private float _time = 0;
    private bool _moving = false;
    private Transform _currentPoint;
    private int _pathIndex = 0;
    private bool _reachedEnd = false;

    void Start()
    {
        //Set the current Point as the start of the guide Path
        _currentPoint = _guidePath.pathPoints[_pathIndex];
    }
    
    // Update is called once per frame
    void Update()
    {
/*
        if (avatarMovement.ifGreeting == true)
        {
            if (_time > 5f)
            {
                agent.SetDestination(new Vector3(-3.5f, 0f, 3.5f));
            }
            else if (_time < 5f)
            {
                _time += Time.deltaTime;
            }
        } */
        if (!_moving && !_reachedEnd)
        {
            //if guide isn't moving, it means it reached the path point. 
            //when it reached the path point, change path point to the next point. 
            _pathIndex++;
            
            //don't go out of the list. Catch argumentException error
            if (_pathIndex == _guidePath.pathPoints.Count)
            {
                //Set the path as the final point 
                _pathIndex = _guidePath.pathPoints.Count - 1;
                _reachedEnd = true;
            }
            
            _currentPoint =  _guidePath.pathPoints[_pathIndex];
            agent.SetDestination(_currentPoint.position);
            
            //agent have a destination to go hence he will be moving
            _moving = true;
        }

        if (_moving && Vector3.Distance(transform.position, _currentPoint.position) < _threshold)
        {
            _moving = false;
        }

    }
}

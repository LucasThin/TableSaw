using System.Collections;
using System.Collections.Generic;
using Oculus.Platform;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.AI;

public class GuideController : MonoBehaviour
{
    enum AvatarState
    {
        Guiding = 0,
        Waiting = 1,
        PickUp = 2,
        PutDown =3 
        
    }
    
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private GuidePath _guidePath;
    [SerializeField] private AvatarState _state = AvatarState.Guiding;
    [SerializeField] private CheckforPlayer _checkforPlayer;
    [SerializeField] private PickUpPoint _checkPickUp;
    [SerializeField] private LeaveBoxPoint _leaveBoxPoint;
    [SerializeField] private Animator _animator;

    private float _time = 0;
    private bool _reached = false;
    private Transform _currentPoint;
    private int _pathIndex = 0;
    private bool _reachedEnd = false;
    private float _waitTime = 5.0f;
    private bool _pickup = false;

    void Start()
    {
        //Set the current Point as the start of the guide Path
        _currentPoint = _guidePath.pathPoints[_pathIndex];
    }
    
    
    void Update()
    {
        _animator.SetFloat("Speed", agent.velocity.magnitude);
        
        
        if (!_leaveBoxPoint.leaveBox)
        {
            if (!_checkPickUp.pickingUp)
            {
                if (_checkforPlayer._playerFollowing)
                {
                    _state = AvatarState.Guiding;
                }
                else
                {
                    _state = AvatarState.Waiting;
                }
            }
            else
            {
                _state = AvatarState.PickUp;
            }

        }
        else
        {
            _state = AvatarState.PutDown;
        } 
       
        
        if (_state == AvatarState.Guiding)
        {
            Guiding();
            
        } else if (_state == AvatarState.Waiting)
        {
            IsWaiting();
        } else if (_state == AvatarState.PickUp)
        {
            PickingUp();
        } else if (_state == AvatarState.PutDown)
        {
            LeavingBox();
        }
        
    }

    private void LeavingBox()
    {
        agent.SetDestination(_leaveBoxPoint.leaveBoxPoint);
        //_moving = false;

    }

    private void PickingUp()
    {
        _pickup = true;

        if (_pickup)
        {
            agent.isStopped = true;
            Debug.Log("pause");
            Invoke("ResumeMovement", 4);
            _pickup = false;
        }

    }
    
    
    

    // Function that will be called after 4 seconds to resume movement
    void ResumeMovement()
    {
        Debug.Log("Resume");
        // Resume movement to the new destination
        agent.isStopped = false;
        _reached = true;
        if (_reached)
        {
            SetNextDestination();
        }
    }
  
    private void IsWaiting()
    {
        agent.SetDestination(transform.position);

    }
    
    private void Guiding()
    {

        // if the person haven't reached the position
        if (Vector3.Distance(transform.position, _currentPoint.position) > _threshold)
        {
            _reached = false;
            agent.SetDestination(_currentPoint.position);
        }

        /*
        // if person reached the position
        if (Vector3.Distance(transform.position, _currentPoint.position) < _threshold)
        {
            _reached = true;
            if (_reached)
            {
                SetNextDestination();
            }
            agent.SetDestination(_currentPoint.position);
        } 
        
        
        //if guide isn't moving and has not reached the end, it means it reached the path point. 
        if (!_moving && !_reachedEnd)
        {
            SetNextDestination();
            agent.SetDestination(_currentPoint.position);

            //agent have a destination to go hence he will be moving
            _moving = true;
        }

        if (_moving && Vector3.Distance(transform.position, _currentPoint.position) < _threshold)
        {
            _moving = false;
        } */
    }

    private void SetNextDestination()
    {
        //when it reached the path point, change path point to the next point. 
        _pathIndex++;
        _reached = false;
        Debug.Log(_pathIndex);
            
        //don't go out of the list. Catch argumentException error
        if (_pathIndex == _guidePath.pathPoints.Count)
        {
            //Set the path as the final point 
            _pathIndex = _guidePath.pathPoints.Count - 1;
            _reachedEnd = true;
        }
            
        _currentPoint =  _guidePath.pathPoints[_pathIndex];
    }
}

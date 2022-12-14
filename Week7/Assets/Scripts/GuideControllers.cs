using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class GuideControllers : MonoBehaviour
{
    enum AvatarState
    {
        Guiding = 0,
        Waiting = 1,
        Routing = 2
    }
    // Start is called before the first frame update

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private GuidePath _guidePath;
    [SerializeField] private AvatarState _state = AvatarState.Routing;
    [SerializeField] private CheckforPlayer _checkforPlayer;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _camera;

    private bool _reachedPoint = false;
    public int _pathIndex = 0;
    public Transform _currentPoint;
    public float _debug;
    private bool routingCalled = false;
    private bool droppingCalled = false;
    void Start()
    {
        _currentPoint = _guidePath.pathPoints[_pathIndex];
        _animator.SetBool("Carrying",false);
        
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("Speed", agent.velocity.magnitude);
        _debug = Vector3.Distance(transform.position, _currentPoint.position);
        //---- check if avatar reaching point ----
        if (Vector3.Distance(transform.position, _currentPoint.position) < _threshold)
        {
            //move to the path position
            agent.Warp(_currentPoint.position);
            _reachedPoint = true;
        }
        else
        {
            _reachedPoint = false;
        }
        
        
        //----Assigning avatar states based on conditions----
        
        //if it's near the destination
        if (_reachedPoint)
        {
            _state = AvatarState.Routing;
        } else //if it's not near the destination 
        {
            //check if the player is following then choose guiding, if not then its waiting.
            if (_checkforPlayer._playerFollowing)
            {
                _state = AvatarState.Guiding;
            }
            else
            {
                _state = AvatarState.Waiting;
            }
        }
        
        //----Assigning functions based on the Avatar states----
        if (_state == AvatarState.Guiding)
        {
            Guiding();
        }

        if (_state == AvatarState.Routing)
        {
            if (!routingCalled)
            {
                Routing();

                routingCalled = true;
            }

        }

        if (_state == AvatarState.Waiting)
        {
            Waiting();
        }

    }
    
    private void Routing()
    {
        //make sure to not go outside of list
        if (_pathIndex < _guidePath.pathPoints.Count)
        {
            _pathIndex++;
           
        }
        else if (_pathIndex >= _guidePath.pathPoints.Count)
        {
            _pathIndex = _guidePath.pathPoints.Count - 1;
        }

        //set destination of agent to the path 
        _currentPoint = _guidePath.pathPoints[_pathIndex];
        
        //play carrying function if path index is 1
        if (_pathIndex == 1)
        {
            Carrying();
        } else if (_pathIndex == 2)
        {
            if (!droppingCalled)
            {
                Dropping();

                droppingCalled = true;
            } else if (droppingCalled)
            {
                Ending();
            }
            
        }
        
        
    }

    private void Ending()
    {
        agent.transform.LookAt(_camera);
    }

    private void Dropping()
    {
        Debug.Log("DroppingOff");
        //Rotate towards the box
        agent.transform.rotation = _guidePath.pathPoints[1].rotation;

        //play carrying animation then carry pose
        // _animator.Play("Carrying");
        _animator.SetBool("Carrying",false);

    }

    private void Carrying()
    {
        Debug.Log("Carrying");
        //Rotate towards the box
        agent.transform.rotation = _guidePath.pathPoints[0].rotation;

        //play carrying animation then carry pose
       // _animator.Play("Carrying");
       _animator.SetBool("Carrying",true);

        //set active to box
        
        //set destination
        agent.SetDestination(_currentPoint.position);
       // _animator.Play("CarryWalking");

    }

    private void Waiting()
    {
        routingCalled = false;
        
        //pause the agent
        agent.isStopped = true;
    }
    

    private void Guiding()
    {
        routingCalled = false;
        
        
        //keep the destination
        agent.SetDestination(_currentPoint.position);
        
        //resume the agent
        agent.isStopped = false;
        
    }
}

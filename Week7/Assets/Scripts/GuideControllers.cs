using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] private float _threshold = 0.1f;
    [SerializeField] private GuidePath _guidePath;
    [SerializeField] private AvatarState _state = AvatarState.Routing;
    [SerializeField] private CheckforPlayer _checkforPlayer;
    [SerializeField] private Animator _animator;

    private bool _reachedPoint;
    private int _pathIndex = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
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
            Routing();
        }

        if (_state == AvatarState.Waiting)
        {
            Waiting();
        }
        
        
        
       
        
    }
    
    private void Routing()
    {
        _pathIndex++;
        Debug.Log(_pathIndex);
    }

    private void Waiting()
    {
       
    }
    

    private void Guiding()
    {
       
    }
}

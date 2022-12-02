using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum movingState
{
    moving = 0,
    idle = 1,
    rest = 2,
    lift = 3,
    carrying = 4
}

public class DetectingState : MonoBehaviour
{
    public movingState state;
    private Vector3 lastPos;
    private Vector3 currentPos;
    public GameObject _camera;
    private bool ifCarry = false;
    private float _time = 0;

    void Awake()
    {
        lastPos = transform.position;
        state = movingState.idle;
    }

    void Update()
    {
        //transform.position = new Vector3(_camera.transform.position.x, 0f, _camera.transform.position.z);

        currentPos = transform.position;
        float distance = Vector3.Distance(lastPos, currentPos);

        //Debug.Log(ifCarry);

        if (distance > 0.01 && ifCarry == false)
        {
            state = movingState.moving;
            //Debug.Log("Moving state");
        }
        else if (distance > 0.01 && ifCarry == true)
        {
            state = movingState.carrying;
            //Debug.Log("Carrying state");
        }
        else if (_time > 1f && ifCarry == false)
        {
            state = movingState.idle;
            //Debug.Log("idle state");
            _time = 0;
        }
        else if (_time > 1f && ifCarry == true)
        {
            state = movingState.lift;
           //Debug.Log("lift state");
            _time = 0;
        }
        else if (_time < 1f)
        {
            _time += Time.deltaTime;
        }

        lastPos = currentPos;
    }

/*    public void Carrying()
    {
        ifCarry = true;
        //Debug.Log("Blocked");
    }

    public void NoCarry()
    {
        ifCarry = false;
    }*/
}

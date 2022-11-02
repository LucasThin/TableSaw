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
    Vector3 lastPos;
    Vector3 currentPos;
    float _time = 0;

    void Awake()
    {
        lastPos = transform.position;
        state = movingState.idle;
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        currentPos = transform.position;
        float distance = Vector3.Distance(lastPos, currentPos);


        if (distance > 0.4)
        {
            state = movingState.moving;
            Debug.Log("Moving state");
        }
        else if (_time > 2f)
        {
            state = movingState.idle;
            Debug.Log("idle state");
            _time = 0;
        }
        else if (_time < 2f)
        {
            _time += Time.deltaTime;
        }

        lastPos = currentPos;
    }
}

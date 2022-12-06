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
    private bool ifCarry = false;
    private float _time = 0;

    [SerializeField] GameObject IdleTrigger;
    [SerializeField] GameObject WalkingTrigger;
    [SerializeField] GameObject LiftingTrigger;
    [SerializeField] GameObject CarryingTrigger;

    void Awake()
    {
        lastPos = transform.position;
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
            IdleTrigger.SetActive(false);
            WalkingTrigger.SetActive(true);
            LiftingTrigger.SetActive(false);
            CarryingTrigger.SetActive(false);
        }
        else if (distance > 0.01 && ifCarry == true)
        {
            state = movingState.carrying;
            IdleTrigger.SetActive(false);
            WalkingTrigger.SetActive(false);
            LiftingTrigger.SetActive(true);
            CarryingTrigger.SetActive(false);
        }
        else if (_time > 1f && ifCarry == false)
        {
            state = movingState.idle;
            IdleTrigger.SetActive(true);
            WalkingTrigger.SetActive(false);
            LiftingTrigger.SetActive(false);
            CarryingTrigger.SetActive(false);
            _time = 0;
        }
        else if (_time > 1f && ifCarry == true)
        {
            state = movingState.lift;
            IdleTrigger.SetActive(false);
            WalkingTrigger.SetActive(false);
            LiftingTrigger.SetActive(false);
            CarryingTrigger.SetActive(true);
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

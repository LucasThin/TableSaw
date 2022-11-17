using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignState : MonoBehaviour
{
    public DetectingState detectingState;
    public GameObject idleTrigger;
    public GameObject movingTrigger;
    public GameObject liftingTrigger;
    public GameObject carryingTrigger;
    public GameObject idleText;
    public GameObject movingText;
    public GameObject liftingText;
    public GameObject carryingText;


    // Start is called before the first frame update
    void Start()
    {
        idleTrigger.SetActive(false);
        movingTrigger.SetActive(false);
        liftingTrigger.SetActive(false);
        carryingTrigger.SetActive(false);

        idleText.SetActive(false);
        movingText.SetActive(false);
        liftingText.SetActive(false);
        carryingText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //if (detectingState.state == movingState.rest)
        //{
        //    idleTrigger.SetActive(false);
        //    movingTrigger.SetActive(false);
        //    liftingTrigger.SetActive(false);
        //    carryingTrigger.SetActive(false);

        //    idleText.SetActive(false);
        //    movingText.SetActive(false);
        //    liftingText.SetActive(false);
        //    carryingText.SetActive(false);

        //    Debug.Log("break trigger is on");
        //}

        if (detectingState.state == movingState.idle)
        {
            idleTrigger.SetActive(true);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(false);
            carryingTrigger.SetActive(false);

            idleText.SetActive(true);
            movingText.SetActive(false);
            liftingText.SetActive(false);
            carryingText.SetActive(false);

            //Debug.Log("idle trigger is on");
        }

        if (detectingState.state == movingState.moving)
        {
            idleTrigger.SetActive(false);
            movingTrigger.SetActive(true);
            liftingTrigger.SetActive(false);
            carryingTrigger.SetActive(false);

            idleText.SetActive(false);
            movingText.SetActive(true);
            liftingText.SetActive(false);
            carryingText.SetActive(false);

            //Debug.Log("moving state is on");
        }

        if (detectingState.state == movingState.lift)
        {
            idleTrigger.SetActive(false);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(true);
            carryingTrigger.SetActive(false);

            idleText.SetActive(false);
            movingText.SetActive(false);
            liftingText.SetActive(true);
            carryingText.SetActive(false);

            //Debug.Log("lifting state is on");
        }

        if (detectingState.state == movingState.carrying)
        {
            idleTrigger.SetActive(false);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(false);
            carryingTrigger.SetActive(true);

            idleText.SetActive(false);
            movingText.SetActive(false);
            liftingText.SetActive(false);
            carryingText.SetActive(true);

            //Debug.Log("carrying state");
        }
    }
}

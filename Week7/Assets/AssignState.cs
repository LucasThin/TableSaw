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


    // Start is called before the first frame update
    void Start()
    {
        idleTrigger.SetActive(false);
        movingTrigger.SetActive(false);
        liftingTrigger.SetActive(false);
        carryingTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (detectingState.state == movingState.idle)
        {
            idleTrigger.SetActive(true);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(false);
            carryingTrigger.SetActive(false);

            //Debug.Log("idle trigger is on");
        }

        if (detectingState.state == movingState.moving)
        {
            idleTrigger.SetActive(false);
            movingTrigger.SetActive(true);
            liftingTrigger.SetActive(false);
            carryingTrigger.SetActive(false);

            //Debug.Log("moving state is on");
        }

        if (detectingState.state == movingState.lift)
        {
            idleTrigger.SetActive(false);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(true);
            carryingTrigger.SetActive(false);


            //Debug.Log("lifting state is on");
        }

        if (detectingState.state == movingState.carrying)
        {
            idleTrigger.SetActive(false);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(false);
            carryingTrigger.SetActive(true);

            //Debug.Log("carrying state");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectingState : MonoBehaviour
{

    public string movingState;
    public GameObject idelTrigger;
    public GameObject movingTrigger;
    public GameObject liftingTrigger;
    public GameObject carrtyingTrigger;


    // Start is called before the first frame update
    void Start()
    {
        idelTrigger.SetActive(false);
        movingTrigger.SetActive(false);
        liftingTrigger.SetActive(false);
        carrtyingTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingState == "break")
        {
            idelTrigger.SetActive(false);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(false);
            carrtyingTrigger.SetActive(false);

            Debug.Log("break state");
        }

        else if (movingState == "idle")
        {
            idelTrigger.SetActive(true);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(false);
            carrtyingTrigger.SetActive(false);

            Debug.Log("idle state");
        }

        else if (movingState == "moving")
        {
            idelTrigger.SetActive(false);
            movingTrigger.SetActive(true);
            liftingTrigger.SetActive(false);
            carrtyingTrigger.SetActive(false);

            Debug.Log("moving state");
        }

        else if (movingState == "lifting")
        {
            idelTrigger.SetActive(false);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(true);
            carrtyingTrigger.SetActive(false);

            Debug.Log("lifting state");
        }

        else if (movingState == "carrying")
        {
            idelTrigger.SetActive(false);
            movingTrigger.SetActive(false);
            liftingTrigger.SetActive(false);
            carrtyingTrigger.SetActive(true);

            Debug.Log("carrying state");
        }
    }
}

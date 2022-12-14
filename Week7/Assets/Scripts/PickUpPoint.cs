using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoint : MonoBehaviour
{
    public bool pickingUp = false;
    public Vector3 pickUpPoint;

    private void Start()
    {
        pickUpPoint = this.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            pickingUp = true;
            Debug.Log("Enter Pick up Trigger");
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickingUp = false;
    }
}

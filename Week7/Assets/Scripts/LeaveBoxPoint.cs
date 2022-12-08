using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveBoxPoint : MonoBehaviour
{
    public bool leaveBox = false;
    public Vector3 leaveBoxPoint;

    private void Start()
    {
        leaveBoxPoint = this.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Leave Box");
            leaveBox = true;
        }
    }
}

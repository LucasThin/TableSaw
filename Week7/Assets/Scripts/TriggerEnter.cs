using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnter : MonoBehaviour
{
    public bool _workerNear = false;
    public GameObject _collided;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("worker"))
        {
            _collided = other.gameObject;
            _workerNear = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("worker"))
        {
            _collided = null;
            _workerNear = false;
        }
    }
    
}

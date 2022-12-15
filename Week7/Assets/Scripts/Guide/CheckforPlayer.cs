using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckforPlayer : MonoBehaviour
{
    public bool _playerFollowing = true;

    void Update()
    {
      
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            _playerFollowing = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("PlayerBody"))
        {
            //Debug.Log(other.gameObject.name);
            _playerFollowing = true;
        }
    }
}

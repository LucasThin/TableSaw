using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DetectDitection : MonoBehaviour
{
    
    [SerializeField] private List<Transform> haptics = new List<Transform>();
    [SerializeField] private List<GameObject> collidingObjects = new List<GameObject>();
    [SerializeField] private List<float> distances = new List<float>();
    private int x = 0;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //If it is not the manager or worker, leave the function
       
        //When gameobject enter the trigger zone , add to array
        if (other.gameObject.CompareTag("worker") || other.gameObject.CompareTag("manager"))
        {
           // collidingObjects.Add(other.gameObject);
           if (!collidingObjects.Contains(other.gameObject))
           {
               collidingObjects.Add(other.gameObject);
               CalculateDistance();
           }
            Debug.Log(other.gameObject.name);
        }
        else
        {
            return;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("worker") || other.gameObject.CompareTag("manager"))
        {
            for(int y = 0; y<haptics.Count; y++)
            {
                distances[y] = Vector3.Distance(collidingObjects[x].transform.position, haptics[y].transform.position);
            }
        }
    }

    //Calculate the distance between list objects and all 3 haptic game objects. 
    //Save theme to a variable
    //Compare the distance between 3 variables
    //the variable with the shortest distance , excute a haptic function
    private void CalculateDistance()
    {
        foreach (var haptic in haptics)
        {
            float distance = Vector3.Distance(collidingObjects[x].transform.position, haptics[x].transform.position);
            distances.Add(distance);
        }
    }

}

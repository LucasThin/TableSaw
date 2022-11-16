using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DetectDitection : MonoBehaviour
{
    
    [SerializeField] private List<GameObject> haptics = new List<GameObject>();
    [SerializeField] private List<GameObject> collidingObjects = new List<GameObject>();
    [SerializeField] private List<float> distances = new List<float>();
    private int x = 0;

    [SerializeField] private XRBaseController leftController;
    [SerializeField] private XRBaseController rightController;
    [SerializeField] private PlayBhaptics _playBhaptics;
    
    [SerializeField] private GameObject backView;
    private bool _removeList = false;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //If it is not the manager or worker, leave the function
       
        //When gameobject enter the trigger zone , add to array
        if (other.gameObject.CompareTag("manager"))
        {
            if (!collidingObjects.Contains(other.gameObject))
           {
               collidingObjects.Add(other.gameObject);
               CalculateDistance();
           }
           Debug.Log(other.gameObject.name);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("manager"))
        {
            for(int y = 0; y<haptics.Count; y++)
            {
                distances[y] = Vector3.Distance(collidingObjects[x].transform.position, haptics[y].transform.position);
            }
        }
        
        FindLowestDistance();
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

    private void FindLowestDistance()
    {
        var min = Mathf.Infinity;
        int minDirection = 10;
 
        for (int i = 0; i < distances.Count; i++)
        {
            if (distances[i] < min)
            {
                min = distances[i];
                minDirection = i;
            }
        }
        Debug.Log(minDirection);
        
        //coming from the back
        if (minDirection == 0)
        {
            haptics[0].SetActive(true);
            haptics[1].SetActive(false);
            haptics[2].SetActive(false);
            haptics[3].SetActive(false);
            _playBhaptics.Haptics(10f-0.1f * min, 0.1f*min);
            backView.SetActive(true);
                
        }
        //coming from the front
        else if (minDirection == 1)
        {
            haptics[0].SetActive(false);
            haptics[1].SetActive(true);
            haptics[2].SetActive(false);
            haptics[3].SetActive(false);
            leftController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
            rightController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
        }
        //coming from the left
        else if (minDirection == 2)
        {
            haptics[0].SetActive(false);
            haptics[1].SetActive(false);
            haptics[2].SetActive(true);
            haptics[3].SetActive(false);
            leftController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
        }
        //coming from the right
        else if (minDirection == 3)
        {
            haptics[0].SetActive(false);
            haptics[1].SetActive(false);
            haptics[2].SetActive(false);
            haptics[3].SetActive(true);
            rightController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        backView.SetActive(false);
        if (collidingObjects.Contains(other.gameObject))
        {
            collidingObjects.Remove(other.gameObject);
               
        }

        _removeList = true;
    }

    private void Update()
    {
        if (_removeList)
        {
            foreach (var distance in distances)
            {
                distances.Remove(distance);
            }

            _removeList = false;
        }
    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    public HapticSensors _hapticSensors;
    [SerializeField] private List<Transform> _haptics = new List<Transform>();
    public List<float> distances = new List<float>();
    [SerializeField] private GameObject AlertModel;
    [SerializeField] private GameObject Model;
    [SerializeField] private GameObject Avatar;
    [SerializeField] private GameObject AlertPlayer;
    [SerializeField] private GameObject AlertLight;
    private int x = 0;

    private bool _removeList;


    // Start is called before the first frame update
    void Start()
    {
        AlertModel.SetActive(false);
        AlertPlayer.SetActive(false);
        AlertLight.SetActive(false);
        Avatar.SetActive(false);
        Model.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Update all distances between
            AlertModel.SetActive(true);
            AlertPlayer.SetActive(true);
            Avatar.SetActive(true);
            AlertLight.SetActive(true);
            Model.SetActive(false);

            for (int y = 0; y<_haptics.Count; y++)
            {
                distances[y] = Vector3.Distance(transform.position, _haptics[y].position);
            }
            FindLowestDistance();
        }
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //On Trigger enter, start calculating the distance function
            CalculatingDistance();
        }
      
    }

    void CalculatingDistance()
    {
        //Retrieve all haptic transforms
        _haptics = _hapticSensors.haptics;
        
        //Calculate all the distances once initially
        foreach (var haptic in _haptics)
        {
            float distance = Vector3.Distance(transform.position, _haptics[x].position);
            distances.Add(distance);
        }
        
       // Debug.Log("Calculating distance");
    }
    
    private void OnTriggerExit(Collider other)
    {
        _removeList = true;
        AlertModel.SetActive(false);
        AlertPlayer.SetActive(false);
        Avatar.SetActive(false);
        AlertLight.SetActive(false);
        Model.SetActive(true);
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
        //Debug.Log("finding lowest distance");
         
        //coming from the back
        if (minDirection == 0)
        {
            Debug.Log("Coming from the back");
            // _playBhaptics.Haptics(10f-0.1f * min, 0.1f*min);

        }
        //coming from the front
        else if (minDirection == 1)
        {
            Debug.Log("Coming from the front");
           // leftController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
           // rightController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
        }
        //coming from the left
        else if (minDirection == 2)
        {
            Debug.Log("Coming from the left");
            //OVRInput.SetControllerVibration(1.0f - 0.1f * min, 0.1f * min, OVRInput.Controller.LTouch);
            //leftController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
        }
        //coming from the right
        else if (minDirection == 3)
        {
            Debug.Log("Coming from the right");
            //OVRInput.SetControllerVibration(1.0f - 0.1f * min, 0.1f * min, OVRInput.Controller.RTouch);
            //rightController.SendHapticImpulse(1.0f-0.1f * min, 0.1f * min);
        }
    }

} 
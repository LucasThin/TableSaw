using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    public HapticSensors _hapticSensors;
    [SerializeField] private List<Transform> _haptics = new List<Transform>();
    public List<float> distances = new List<float>();

    [SerializeField] private GameObject alertWorker;
    [SerializeField] private GameObject normalWorker;
    [SerializeField] private GameObject Guide;
    [SerializeField] private GameObject alertPlayer;
    [SerializeField] private GameObject normalPlayer;
    [SerializeField] private GameObject AlertLight;
    [SerializeField] private ArduinoVest _arduinoVest;
    private int x = 0;

    private bool _removeList;


    // Start is called before the first frame update
    void Start()
    {
        alertWorker.SetActive(false);
        alertPlayer.SetActive(false);
        AlertLight.SetActive(false);
        Guide.SetActive(false);
        normalWorker.SetActive(true);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Update all distances between
            alertWorker.SetActive(true);
            alertPlayer.SetActive(true);
            Guide.SetActive(true);
            AlertLight.SetActive(true);
            normalWorker.SetActive(false);

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
        alertWorker.SetActive(false);
        alertPlayer.SetActive(false);
        Guide.SetActive(false);
        AlertLight.SetActive(false);
        normalWorker.SetActive(true);
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
         
        //coming from the left
        if (minDirection == 2)
        {
            Debug.Log("Coming from the left");
            _arduinoVest.OnHapticsRight();
        }
        //coming from the frontleft
        if (minDirection == 0)
        {
            Debug.Log("Coming from the frontleft");
            _arduinoVest.OnHapticsFrontLeft();

        }
        //coming from the frontright
        if (minDirection == 1)
        {
            Debug.Log("Coming from the frontright");
            _arduinoVest.OnHapticsFrontright();

        }
        //coming from the backleft
        if (minDirection == 4)
        {
            Debug.Log("Coming from the backleft");
            _arduinoVest.OnHapticsBackLeft();
        }
        //coming from the backright
        if (minDirection == 5)
        {
            Debug.Log("Coming from the backright");
            _arduinoVest.OnHapticsBackRight();
        }
        //coming from the right
        if (minDirection == 3)
        {
            Debug.Log("Coming from the right");
            _arduinoVest.OnHapticsRight();
        }
    }

} 
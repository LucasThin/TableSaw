using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    public HapticSensors _hapticSensors;
    [SerializeField] private List<Transform> _haptics = new List<Transform>();
    public List<float> distances = new List<float>();
    public bool _frontLeft = false, _frontRight = false, _left = false, _right = false, _backLeft = false, _backRight = false;

    [SerializeField] private GameObject alertWorker;
    [SerializeField] private GameObject normalWorker;
    [SerializeField] private GameObject Guide;
    [SerializeField] private GameObject alertPlayer;
    [SerializeField] private GameObject normalPlayer;
    [SerializeField] private GameObject AlertLight;
    [SerializeField] private ArduinoVest _arduinoVest;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private GuideAudioManager _guideAudioManager;
    private int x = 0;

    private bool _removeList;
    private bool _playedInfront = false, _playedBehind = false, _playedLeft = false, _playedRight = false;


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

        if (_frontLeft || _backLeft || _left)
        {
            _uiManager.moveLeftOff();
            _uiManager.moveRightOn();
        }

        if (_frontRight || _backRight || _right)
        {
            _uiManager.moveRightOff();
            _uiManager.moveLeftOn();
        }

        if (_frontLeft || _frontRight)
        {

            if (!_playedInfront)
            {
                _guideAudioManager.StopAllAudio();
                SoundManager.Instance.PlayLine(_guideAudioManager._audioClips[5]);
                _playedInfront = true;
            }
            else
            {
                _playedInfront = false;
            }
            
        }
        
        if (_backLeft || _backRight)
        {
            if (!_playedBehind)
            {
                _guideAudioManager.StopAllAudio();
                SoundManager.Instance.PlayLine(_guideAudioManager._audioClips[4]);
                _playedBehind = true;
            }
            else
            {
                _playedBehind = false;
            }
            
        }

        if (_left)
        {
            if (!_playedLeft)
            {
                _guideAudioManager.StopAllAudio();
                SoundManager.Instance.PlayLine(_guideAudioManager._audioClips[6]);
                _playedLeft = true;
            }
            else
            {
                _playedLeft = false;
            }
        }

        if (_right)
        {
            if (!_playedLeft)
            {
                _guideAudioManager.StopAllAudio();
                SoundManager.Instance.PlayLine(_guideAudioManager._audioClips[7]);
                _playedRight = true;
            }
            else
            {
                _playedRight = false;
            }
            
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
           // Debug.Log("Coming from the left");
            _arduinoVest.OnHapticsLeft();
            _right = false;
            _frontLeft = false;
            _frontRight = false;
            _backLeft = false;
            _backRight = false;
            _left = true;

        }
        //coming from the frontleft
        if (minDirection == 0)
        {
           // Debug.Log("Coming from the frontleft");
            _arduinoVest.OnHapticsFrontLeft();
            _frontLeft = true;
            _right = true;
            _frontRight = false;
            _backLeft = false;
            _backRight = false;
            _left = false;

        }
        //coming from the frontright
        if (minDirection == 1)
        {
           // Debug.Log("Coming from the frontright");
            _arduinoVest.OnHapticsFrontright();
            _frontRight = true;
            _right = false;
            _frontLeft = false;
            _backLeft = false;
            _backRight = false;
            _left = false;
        }
        //coming from the backleft
        if (minDirection == 4)
        {
           // Debug.Log("Coming from the backleft");
            _arduinoVest.OnHapticsBackLeft();
            _backLeft = true;
            _right = false;
            _frontLeft = false;
            _frontRight = false;
            _backRight = false;
            _left = false;
        }
        //coming from the backright
        if (minDirection == 5)
        {
           // Debug.Log("Coming from the backright");
            _arduinoVest.OnHapticsBackRight();
            _backRight = true;
            _right = false;
            _frontLeft = false;
            _frontRight = false;
            _backLeft = false;
            _left = false;

        }
        //coming from the right
        if (minDirection == 3)
        {
            //Debug.Log("Coming from the right");
            _arduinoVest.OnHapticsRight();
            _right = true;
            _frontLeft = false;
            _frontRight = false;
            _backLeft = false;
            _backRight = false;
            _left = false;
            
        }
    }

} 
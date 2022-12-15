using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    public HapticSensors _hapticSensors;
    [SerializeField] private List<Transform> _haptics = new List<Transform>();
    public List<float> distances;

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

            for (int y = 0; y<(_haptics.Count-1); y++)
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
            foreach (var distance in distances.ToList())
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
           // Debug.Log("Coming from the left");
            _arduinoVest.OnHapticsLeft();
            _uiManager.moveLeftOff();
            _uiManager.moveRightOn();
            
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
        //coming from the frontleft
        if (minDirection == 0)
        {
           // Debug.Log("Coming from the frontleft");
            _arduinoVest.OnHapticsFrontLeft();
            _uiManager.moveLeftOff();
            _uiManager.moveRightOn();
            
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
        //coming from the frontright
        if (minDirection == 1)
        {
           // Debug.Log("Coming from the frontright");
            _arduinoVest.OnHapticsFrontright();
            _uiManager.moveRightOff();
            _uiManager.moveLeftOn();
            
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
        //coming from the backleft
        if (minDirection == 4)
        {
           // Debug.Log("Coming from the backleft");
            _arduinoVest.OnHapticsBackLeft();
            _uiManager.moveLeftOff();
            _uiManager.moveRightOn();
            
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
        //coming from the backright
        if (minDirection == 5)
        {
           // Debug.Log("Coming from the backright");
            _arduinoVest.OnHapticsBackRight();
            _uiManager.moveRightOff();
            _uiManager.moveLeftOn();
            
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
        //coming from the right
        if (minDirection == 3)
        {
            //Debug.Log("Coming from the right");
            _arduinoVest.OnHapticsRight();
            _uiManager.moveRightOff();
            _uiManager.moveLeftOn();
            
            if (!_playedRight)
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

} 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuideAudioManager : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float _threshold = 1f;
    [SerializeField] private GuidePath _guidePath;
    [SerializeField] private GuideControllers _guideControllers;
    public List<AudioClip> _audioClips;

    private bool infront = false, left = false, right = false, behind = false;
    private bool _audioPlayed = false;
    public bool _afterPickUp = false;
    public bool _enterConveyerBelt = false, _reachedDestination = false;

    private AudioSource[] allAudioSources;
    void Awake()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
    }

    public void StopAllAudio()
    {

        foreach (var audios in allAudioSources)
        {
            audios.Stop();
        }

    }
    

    void Update()
    {
        //When agent is near the pick up point
        if (_guideControllers._carrying)
        {
            if (!_audioPlayed)
            {
                StopAllAudio();
                SoundManager.Instance.PlayLine(_audioClips[0]);
                Debug.Log("play line");

                _audioPlayed = true;
            }
        }

        if (_guideControllers._reachedEnd)
        {
            ReachedDestination();
        }
      
    }

    public void AfterPickingUp()
    {
        if (!_afterPickUp)
        {
            StopAllAudio();
            SoundManager.Instance.PlayLine(_audioClips[1]);
            Debug.Log("afterboxpickup line");

            _afterPickUp = true;
        }
    }

    public void ApproachConveyorBelt()
    {
        if (!_enterConveyerBelt)
        {
            StopAllAudio();
            SoundManager.Instance.PlayLine(_audioClips[2]);
            Debug.Log("Enter Conveyer belt");

            _enterConveyerBelt = true;

        }
    }

    public void ResetBelt()
    {
        
        _enterConveyerBelt = false;
    }

    public void ReachedDestination()
    {
        if (!_reachedDestination)
        {
            StopAllAudio();
            SoundManager.Instance.PlayLine(_audioClips[8]);
            Debug.Log("Reached Destination");

            _reachedDestination = true;

        }
    }
    
}

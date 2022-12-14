using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting : MonoBehaviour
{
    [SerializeField] private GameObject _guideController;
    [SerializeField] private Animator _guideAnimator;

    [SerializeField] private float _animationTime = 5f;
    
    private void Awake()
    {
        _guideController.SetActive(false);
    }

    void Start()
    {
        
        _guideAnimator.SetTrigger("Salute");
        Invoke("StartAnimation", _animationTime);
    }

    void StartAnimation()
    {
        Debug.Log("start animating");
        _guideController.SetActive(true);
    }
}

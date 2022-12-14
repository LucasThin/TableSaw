using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeting : MonoBehaviour
{
    [SerializeField] private GameObject _guideController;
    [SerializeField] private Animator _guideAnimator;
    // Start is called before the first frame update
    void Start()
    {
        _guideAnimator.SetTrigger("Salute");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

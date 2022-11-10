using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WalkTowards : MonoBehaviour
{
    [SerializeField] private GameObject _headset;
    [SerializeField] private GameObject backCamera;
    [SerializeField] private GameObject _glow;
    //public VibrateController vibration;

    [SerializeField] private XRBaseController controller;


    // Start is called before the first frame update
    void Start()
    {
        _glow.SetActive(false);
        backCamera.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(_headset.transform.position, transform.position);
        //Debug.Log(distance);

        if (distance < 5 && distance > 3)
        {
            _glow.SetActive(true);
            controller.SendHapticImpulse(0.7f - 0.1f * distance, 0.25f + 0.1f * distance);
            backCamera.SetActive(true);
        }
        if (distance <= 3)
        {
            _glow.SetActive(true);
            controller.SendHapticImpulse(1.0f-0.1f * distance, 0.1f * distance);
            backCamera.SetActive(true);
        }
        else _glow.SetActive(false);
    }
}

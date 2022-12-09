using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource BGMsource;
    [SerializeField] private AudioClip warehouseMusic;
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        BGMsource.PlayOneShot(warehouseMusic);
    }
}

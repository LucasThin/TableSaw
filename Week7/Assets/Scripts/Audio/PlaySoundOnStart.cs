using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip _clip;

    void Start()
    {
        SoundManager.Instance.PlayLine(_clip);
        if (_clip) {
            Debug.Log(_clip.name);
        } else {
            Debug.Log("No game object called clip found");
        }
    }
}

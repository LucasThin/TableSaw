using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _backgroundSource, _effectsSource, _voiceLinesSource;
    
    void Awake()
    {
        //Singleton. If there's no soundmanager, don't delete this game object, if there is, delete it.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayLine(AudioClip clip)
    {
        _voiceLinesSource.PlayOneShot(clip);
    }
    
}

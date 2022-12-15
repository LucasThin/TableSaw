using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimation : MonoBehaviour
{
    [SerializeField] Animator _animator;

    public void _stopAnimation()
    {
        _animator.SetBool("Stop", true);
    }

    public void _playAnimation()
    {
        _animator.SetBool("Stop", false);
    }
}

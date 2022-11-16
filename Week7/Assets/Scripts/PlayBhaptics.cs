using System.Collections;
using System.Collections.Generic;
using Bhaptics.SDK2;
using UnityEngine;

public class PlayBhaptics : MonoBehaviour
{

    // Start is called before the first frame update
    public void Haptics(float intensity, float duration)
    {
        BhapticsLibrary.PlayParam(BhapticsEvent.SENSEBACK,
            intensity: intensity,   // The value multiplied by the original value
            duration: duration,    // The value multiplied by the original value
            angleX: 20f,     // The value that rotates around global Vector3.up(0~360f)
            offsetY: 0.3f);  // The value to move up and down(-0.5~0.5)
    } 
    
    public void StrongHaptics()
    {
        BhapticsLibrary.PlayParam(BhapticsEvent.SENSEBACK,
            intensity: 1f,   // The value multiplied by the original value
            duration: 1f,    // The value multiplied by the original value
            angleX: 20f,     // The value that rotates around global Vector3.up(0~360f)
            offsetY: 0.3f);  // The value to move up and down(-0.5~0.5)
    }
    
    
    
}

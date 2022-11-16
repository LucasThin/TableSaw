using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    // Start is called before the first frame update
    public int oldMask;
    void Start()
    {
        oldMask = _mainCamera.cullingMask;
      //  _mainCamera.cullingMask = ~(1 << LayerMask.NameToLayer("ToggleUI"));
    }
    
    public void ToggleUIOn()
    {
        Debug.Log("change culling mask");
        _mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("ToggleUI");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

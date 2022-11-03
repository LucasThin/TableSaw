using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTextures : MonoBehaviour
{
    public Material red, blue, green, gray, orange;
    private Renderer m_Renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        m_Renderer.enabled = true;
        m_Renderer.sharedMaterial = gray;
    }

    // Update is called once per frame
    public void ChangeToBlue()
    {
        Debug.Log("change to blue");
        m_Renderer.sharedMaterial = blue;
    }
    
    public void ChangeToRed()
    {
        Debug.Log("change to red");
        m_Renderer.sharedMaterial = red;
    }
    
    public void ChangeToGray()
    {
        Debug.Log("change to gray");
        m_Renderer.sharedMaterial = gray;
    }
    
    public void ChangeToGreen()
    {
        Debug.Log("change to green");
        m_Renderer.sharedMaterial = green;
    }
    
    public void ChangeToOrange()
    {
        Debug.Log("change to orange");
        m_Renderer.sharedMaterial = orange;
    }
}

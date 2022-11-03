using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlock : MonoBehaviour
{
    public bool ifEyeBlock;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        ifEyeBlock = true;
        Debug.Log("Carry stuff");
    }

    void OnTriggerExit()
    {
        ifEyeBlock = false;
        Debug.Log("Nothing in hands.");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class OnHaptics : MonoBehaviour
{
    public MeshRenderer _debugMesh;
    private SerialPort portNo = new SerialPort("COM6", 9600);
    void Start()
    {
        portNo.Open();
        portNo.ReadTimeout = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        if (!portNo.IsOpen)
            portNo.Open();
        if (portNo.IsOpen)
        {
            try
            {
                Debug.Log(portNo.ReadByte());
                OnHaptic(portNo.ReadByte());
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }

    void OnHaptic(int stat)
    {
        if (stat == 1)
        {
            _debugMesh.enabled = true;
           // Debug.Log("1");
        }
        else if (stat == 2)
        {
            _debugMesh.enabled = false;
          //  Debug.Log("2");
        }
    }
}

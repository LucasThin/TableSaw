using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class OnHaptics : MonoBehaviour
{
    //public MeshRenderer _debugMesh;
    public string message2;
    public SerialPort portNo = new SerialPort("COM6", 9600);
    void Start()
    {
        OpenConnection();
    }

    private void OpenConnection()
    {
        if (portNo != null)
        {
            if (portNo.IsOpen)
            {
                portNo.Close();
                print("Closing port, because it was already open!");
            }
            else
            {
                portNo.Open();
                portNo.ReadTimeout = 16;
                print("Port Opened!");
            }
        }
        else
        {
            if (portNo.IsOpen)
            {
                print("Port is already open");
            }
            else
            {
                print("Port == null");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // message2 = portNo.ReadLine();
       // print(message2);
    }

    public void SendHaptic()
    {
        Debug.Log("SendHaptic");
        portNo.Write("Y");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Arduino2Unity : MonoBehaviour
{
    public static string portName = "COM3";
    public static int portSpeed = 9600;
    public SerialPort sp = new SerialPort(portName, portSpeed);
    public int byteValue;
    public GameObject gobj;

    // Start is called before the first frame update
    void Awake()
    {
        OpenConnection();
    }

    // Update is called once per frame
    void Update()
    {
        if (sp.IsOpen)
        {
            byteValue = sp.ReadByte();
        }
        //stringValue = ReceiveString();
        //text.text = stringValue;
        if (byteValue == 10)
        {
            gobj.SetActive(true);
        }
        else if (byteValue == 20)
        {
            gobj.SetActive(false);
        }
        //Debug.Log(byteValue);
    }

    public void OpenConnection()
    {
        if (sp != null)
        {
            if (sp.IsOpen)
            {
                sp.Close();
                Debug.Log("Closing port, because it's already open");
            }
            else
            {
                sp.Open();
                sp.ReadTimeout = 100;
                Debug.Log("port open at" + portName + portSpeed);
            }
        }
        else
        {
            if (sp.IsOpen)
            {
                Debug.Log("port is already open");
            }
            else
            {
                Debug.Log("port == null");
            }
        }

    }
}

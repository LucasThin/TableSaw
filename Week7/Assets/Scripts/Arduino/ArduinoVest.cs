using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoVest : MonoBehaviour
{
    public static string portName = "COM6";
    public static int portSpeed = 9600;
    private SerialPort sp = new SerialPort(portName, portSpeed);
    private bool state;
    private string byteValue;

    [SerializeField] private bool button = false;
    [SerializeField] private ToggleUI _toggleUI;
    
    void Awake()
    {
        OpenConnection();
        
    }

    void Update()
    {
       
        if (sp.IsOpen)
        {
            string value = ReadSerialPort();
         
         if (value != null)
         //if (value != null && float.Parse(value) >= 1.0f)
         {
             //Debug.Log(value);
             
             if (value == "up")
             {
                 button = true;
                 _toggleUI.ToggleUIOn();

             }
             else if (value == "down")
             {
                 button = false;
             }
         }

        }
        
    }

    public void OnHapticsFrontLeft()
    {
        sp.Write("FL");
        Debug.Log("FL");
    }
    
    public void OnHapticsFrontright()
    {
        sp.Write("FR");
        Debug.Log("FR");
    }
    
    public void OnHapticsBackLeft()
    {
        sp.Write("BL");
        Debug.Log("BL");
    }
    
    public void OnHapticsBackRight()
    {
        sp.Write("BR");
        Debug.Log("BR");
    }
    
    public void OnHapticsLeft()
    {
        sp.Write("SL");
        Debug.Log("SL");
    }
    
    public void OnHapticsRight()
    {
        sp.Write("SR");
        Debug.Log("SR");
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
                sp.ReadTimeout = 1;
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



    public string ReadSerialPort(int timeout = 10)
    {
        string readByte;
        sp.ReadTimeout = timeout;
        //we will try to read values from our serial port
        try
        {
            readByte = sp.ReadLine();
            return readByte;
        }
        catch(TimeoutException)
        {
            return null;
        }
    }
    
    public void TurnOnBehaviour()
    {
        sp.Write("O");
        Debug.Log("on");
    }

    public void TurnOffBehaviour()
    {
        sp.Write("F");
        Debug.Log("off");
    }
    
}

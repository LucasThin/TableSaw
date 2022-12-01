using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEditor;


public class Testblock : MonoBehaviour
{
   
    SerialPort portNo = new SerialPort("COM8", 9600);

    public float ftime;
    public float stepTime = 0.2f;

    void Start()
    {
        portNo.Open();
        portNo.ReadTimeout = 5000;
    }

    // Update is called once per frame
    void Update()
    {
        ftime += Time.deltaTime;

        if (ftime >= stepTime)
        {
            if (portNo.IsOpen)
            {
                //Debug.Log("open");
                try
                {
                    cube_on(portNo.ReadByte());

                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            ftime = 0f;
        }
    }

    void cube_on(int stat)
    {
        if (stat == 1)
        {
            Debug.Log("button pressed");
            this.gameObject.SetActive(true);
        }

        if (stat == 2)
        {
            Debug.Log("-");
            this.gameObject.SetActive(false);
        }


    }
}
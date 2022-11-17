using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Arduino : MonoBehaviour
{
    [SerializeField] private GameObject _cube;
    SerialPort portNo = new SerialPort("COM8", 9600);

    public float ftime;
    public float stepTime = 0.2f;
    public bool DtrEnable { get; set; }
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        portNo.Open();
        portNo.ReadTimeout = 100000;
        DtrEnable = true;
    }

   
    // Update is called once per frame
    void Update()
    {
        
        ftime += Time.deltaTime;

        if (ftime >= stepTime)
        {
            if (portNo.IsOpen)
            {
                Debug.Log("open");
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

    private void cube_on(int readByte)
    {
        //Debug.Log(readByte);
        if (readByte == 1)
        {
            _cube.SetActive(true);
            Debug.Log("button pressed");
            
        }

        if (readByte == 2)
        {
            _cube.SetActive(false);
            Debug.Log("-");
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningFast : MonoBehaviour
{

    public GameObject clothes;
    public Material defMat;
    public Material dangerMat;
    private Vector3 lastPos;
    private Vector3 currentPos;
    float _time = 0;


    // Start is called before the first frame update
    void Start()
    {
        clothes.GetComponent<Renderer>().material = defMat;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        float distance = Vector3.Distance(lastPos, currentPos);

        if (distance > 0.05)
        {
            clothes.GetComponent<Renderer>().material = dangerMat;
            Debug.Log("Dangerous");
        }
        else
        {
            clothes.GetComponent<Renderer>().material = defMat;
            _time = 0;
        }


        lastPos = currentPos;
    }

}

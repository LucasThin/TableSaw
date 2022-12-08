using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftControl : MonoBehaviour
{
    [SerializeField] GameObject _forklift;
    [SerializeField] GameObject _worker;
    private bool triggerForklift = false;
    private bool triggerWorker = false;
    private bool stopForklift = false;
    private bool stopWorker = false;
    private float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerForklift == true)
        {
            float _distance = Vector3.Distance(_worker.transform.position, new Vector3 (-3.48f,0f,0.23f));
            if (_distance > 1f) 
            {
                _worker.transform.Translate(Vector3.forward * 1.2f * Time.deltaTime); 
            }

            if(stopForklift == false)
            {
                _forklift.transform.Translate(Vector3.forward * 0.7f * Time.deltaTime);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerForklift = true;
            triggerForklift = true;
        }
        if (other.CompareTag("Forklift"))
        {
            stopForklift = true;
        }
    }
}

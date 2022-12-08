using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftControl : MonoBehaviour
{
    [SerializeField] GameObject _forklift;
    private bool triggerForklift = false;
    private bool stopForklift = false;
    private float _time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerForklift == true && stopForklift == false)
        {
          _forklift.transform.Translate(Vector3.forward * 0.7f * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerForklift = true;
        }
        if (other.CompareTag("Forklift"))
        {
            stopForklift = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftControl : MonoBehaviour
{
    [SerializeField] GameObject _forklift;
    private float _time = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_time > 4f && _time < 6f)
        {
            _forklift.transform.Translate(Vector3.forward * 0.7f * Time.deltaTime);
        }
        if (_time < 7f)
        {
            _time += Time.deltaTime;
        }

    }
}


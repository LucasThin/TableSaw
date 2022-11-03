using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBlock : MonoBehaviour
{
    private float range = 0.75f;
    public GameObject birdView;

    // Update is called once per frame
    void Start()
    {
        birdView.SetActive(false);
    }

    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range));

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            Debug.Log("Sight is blocked!");
            birdView.SetActive(true);
        }
        else birdView.SetActive(false);
    }
}
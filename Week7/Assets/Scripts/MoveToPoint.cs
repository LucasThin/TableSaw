using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour
{
    //[SerializeField] private GameObject _destination;

    public void Update()
    {
        this.transform.Translate(new Vector3(0, 0, 0.03f));
    }
}

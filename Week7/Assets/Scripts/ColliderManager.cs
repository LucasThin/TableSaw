using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    [SerializeField] private List<TriggerEnter> _colliderObjects;

    public CalculateDistance _calculateDistance;
    void Update()
    {
        //check through the list if theres any trigger enter
        foreach (var colliderTrigger in _colliderObjects)
        {
            if (colliderTrigger._workerNear)
            {
                Debug.Log(colliderTrigger._collided.name);
                _calculateDistance = colliderTrigger._collided.GetComponent<CalculateDistance>();
            }
        }
    }
}

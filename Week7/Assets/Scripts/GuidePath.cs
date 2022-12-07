using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePath : MonoBehaviour
{

    [SerializeField] private List<Transform> _pathPoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < (_pathPoints.Count -1); i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_pathPoints[i].position, _pathPoints[i + 1].position);
        }
    }
}

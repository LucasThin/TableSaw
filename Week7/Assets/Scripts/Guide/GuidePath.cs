using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuidePath : MonoBehaviour
{

    [SerializeField] public List<Transform> pathPoints;
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
        for(int i = 0; i < (pathPoints.Count -1); i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }
    }
}

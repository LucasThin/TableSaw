using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedGround : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = player.transform.position;
        transform.position = new Vector3(player.transform.position.x, 0f, player.transform.position.z + 1.5f);
    }
}

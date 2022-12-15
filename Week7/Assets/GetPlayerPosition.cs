using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerPosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
    }
}

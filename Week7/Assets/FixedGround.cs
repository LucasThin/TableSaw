using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedGround : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //originalOffset = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Hip's position
        Vector3 pos = player.transform.position;
        this.transform.position = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        Quaternion myRotation = Quaternion.identity;
        myRotation.eulerAngles = new Vector3(0f, player.transform.eulerAngles.y, 0f);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, myRotation, 2000);

    }
}

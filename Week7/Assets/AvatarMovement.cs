using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    [SerializeField] DetectingState detectingState;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Greeting");
            anim.Play("Salute");
        }
        else if (detectingState.state == movingState.moving)
        {
            Debug.Log("Walking");
            anim.Play("Walking 0");
        }
    }
}

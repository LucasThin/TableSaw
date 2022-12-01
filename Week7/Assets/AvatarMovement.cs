using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    [SerializeField] DetectingState detectingState;
    [SerializeField] float degreesPerSecond = 80;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("Salute");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //anim.Play("Right Turn");
            transform.Rotate(0, 180, 0);
            anim.Play("Salute");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 180, 0);
        }
        if (detectingState.state == movingState.moving)
        {
            //Debug.Log("Walking");
            //anim.Play("Walking 0");
            anim.SetBool("isWalking",true);
        }
        else if (detectingState.state == movingState.idle)
        {
            anim.SetBool("isWalking", false);
        }
    }
}

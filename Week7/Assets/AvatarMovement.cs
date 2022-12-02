using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    [SerializeField] DetectingState detectingState;
    [SerializeField] CalculateDistance calculateDistance;
    [SerializeField] float degreesPerSecond = 80;
    private float _time = 0;


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
        if (calculateDistance.distances.Count > 0)
        {
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(-0.5f, 0f, 1.5f), Time.deltaTime * 4);
            //anim.SetTrigger("Dodge");

        }
        if (calculateDistance.distances.Count == 0)
        {
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(0f, 0f, 1.5f), Time.deltaTime * 4);

        }
    }
}

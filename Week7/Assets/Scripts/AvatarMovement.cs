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
    private bool ifDodge;
    public bool ifGreeting;


    void Start()
    {
        anim = GetComponent<Animator>();
        ifDodge = false;
        ifGreeting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            anim.SetTrigger("Salute");
            ifGreeting = true;

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
        if (calculateDistance.distances.Count > 0 && ifDodge == false)
        {
            Vector3 targetPosition = transform.position;
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x - 0.5f, targetPosition.y, targetPosition.z), Time.deltaTime * 4);
            Debug.Log("dodge");
            ifDodge = true;

        }
        if (calculateDistance.distances.Count == 0 && ifDodge == true)
        {
            Vector3 targetPosition = transform.position;
            transform.position = Vector3.Lerp(transform.position, new Vector3(targetPosition.x + 0.5f, targetPosition.y, targetPosition.z), Time.deltaTime * 4);
            ifDodge = false;
        }
    }
}

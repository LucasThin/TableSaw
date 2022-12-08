using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    private Vector3 lastPos;
    private Vector3 currentPos;

    void Start()
    {
        anim = GetComponent<Animator>();
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;

        if (lastPos != currentPos)
        {
            anim.Play("Walking 0");
        }
        else anim.Play("Standing");

        lastPos = currentPos;

    }
}

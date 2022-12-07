using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuideController : MonoBehaviour
{
    [SerializeField] AvatarMovement avatarMovement;
    [SerializeField] NavMeshAgent agent;
    private float _time = 0;

    // Update is called once per frame
    void Update()
    {

        if (avatarMovement.ifGreeting == true)
        {
            if (_time > 5f)
            {
                agent.SetDestination(new Vector3(-3.5f, 0f, 3.5f));
            }
            else if (_time < 5f)
            {
                _time += Time.deltaTime;
            }
        }
    }
}

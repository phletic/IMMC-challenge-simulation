using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class NarrowBody_CharacterController : Character
{

    float forwardVelocity = 0.3f;
    float backwardVelocity = 0f;
    public NarrowBody_CharacterController()
    {

    }
    public override void StartMove(Transform _target, GameObject _agent)
    {
        forwardVelocity *= Time.timeScale;
        movementAction += Move;
        movementManager.agentsMovement.AddListener(movementAction);
        target = _target;
        agent = _agent;
    }

    public void Move()
    {
        if (backwards == true)
        {
            IsWalking = false;
            if (Wait())
            {
                movement();
            }
        }
        else
        {
            movement();
        }

    }

    void movement()
    {
        RaycastHit hit;
        Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.forward) * 1f, Color.red);
        Debug.DrawRay(agent.transform.position, agent.transform.TransformDirection(Vector3.back) * 1f, Color.red);
        if (backwards == true)
        {
            if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.back), out hit, 1f))
            {
                backwardVelocity = forwardVelocity;
                IsWalking = false;
            }
            else
            {
                backwardVelocity = 0f;
                IsWalking = true;
            }
        }
        else
        {
            if (Physics.Raycast(agent.transform.position, agent.transform.TransformDirection(Vector3.forward), out hit, 1f))
            {
                backwardVelocity = forwardVelocity;
                IsWalking = false;
            }
            else
            {
                backwardVelocity = 0f;
                IsWalking = true;
            }
        }
        force = forwardVelocity - backwardVelocity;
        if (backwards)
        {
            force *= -1;
        }
        if (Mathf.Abs(agent.transform.position.z - target.transform.position.z) > 1f)
        {
            agent.transform.Translate(new Vector3(0, 0, force));
        }
        else
        {
            IsWalking = false;
            if (backwards == false)
            {
                if (Wait())
                {
                    RemoveAgent();
                }
            }
            else
            {
                RemoveAgentBack();
            }
        }
    }
}

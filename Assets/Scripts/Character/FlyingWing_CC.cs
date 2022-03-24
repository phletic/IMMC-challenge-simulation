using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using System.Linq;
public class FlyingWing_CC : Character
{

    float forwardVelocity = 0.3f;
    float backwardVelocity = 0f;

    int[] Destination = { 3, 10, 17, 24 };
    public FlyingWing_CC()
    {

    }
    public override void StartMove(Transform _target, GameObject _agent)
    {
        forwardVelocity *= Time.timeScale;
        movementAction += Move;
        movementManager.agentsMovement.AddListener(movementAction);
        target = _target;
        agent = _agent;
        int closestX = Destination.OrderBy(v => Mathf.Abs((int)v - target.position.x)).First();
        if (backwards == false)
        {
            agent.GetComponent<NavMeshAgent>().SetDestination(new Vector3(closestX, agent.transform.position.y, target.position.z));
            agent.GetComponent<CharacterImplement>().TargetVector = new Vector3(closestX, agent.transform.position.y, target.position.z);
        }
        else
        {
            agent.GetComponent<NavMeshAgent>().SetDestination(target.position);
        }
    }

    public void Move()
    {
        try{
        if(Mathf.Abs(agent.GetComponent<NavMeshAgent>().velocity.magnitude) > 0.3f){
            IsWalking = true;
        }
        else{
            IsWalking = false;
        }
        }
        catch{
            return;
        }
        if(backwards){
            if(Wait() == false){
                agent.GetComponent<NavMeshAgent>().speed = 0f;
                return;
            }else{
                agent.GetComponent<NavMeshAgent>().speed = 3.5f;
            }
        }
        if (Mathf.Abs(agent.transform.position.z - target.transform.position.z) > 0.1f)
        {
            agent.transform.Translate(new Vector3(0, 0, force));
        }
        else
        {
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
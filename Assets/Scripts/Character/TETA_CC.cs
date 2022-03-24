using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using System.Linq;
public class TETA_CC : Character
{

    float forwardVelocity = 0.3f;
    float backwardVelocity = 0f;

    Vector3 newTarget;
    public TETA_CC(){}
    public override void StartMove(Transform _target, GameObject _agent){
        forwardVelocity *= Time.timeScale;
        movementAction += Move;
        movementManager.agentsMovement.AddListener(movementAction);
        target = _target;
        agent = _agent;
        agent.GetComponent<NavMeshAgent>().speed = 1.5f;
    }

    public void Move(){
        if(Mathf.Abs(agent.GetComponent<NavMeshAgent>().velocity.magnitude) > 0.3f){
            IsWalking = true;
        }
        else{
            IsWalking = false;
        }
        if (backwards){
            if(Wait() == false){
                return;
            }
        }
        float closestX = 0;
        if(target.position.x >= 1 && target.position.x <= 5){
            if(target.position.z >= 0 && target.position.z <= 3)closestX = 2f;
            else{
                closestX = 5f;   
            }
        }
        if((target.position.x == 7) ){
            if(target.position.z == 0 || target.position.z == 1){
                closestX = 2f;
            }
            else{
                closestX = 6f;
            }
        }
        if(target.position.x >= 8 && target.position.z <= 19){
            if(target.position.z >= 0 && target.position.z <=3){
                closestX = 2f;
            }else{
                closestX = 6f;
            }
        }
        if((target.position.x == 22) ){
            if(target.position.z == 0 || target.position.z == 1){
                closestX = 2f;
            }
            else{
                closestX = 6f;
            }
        }
        if(target.position.x >= 24 && target.position.z <= 43){
            if(target.position.z >= 0 && target.position.z <=3){
                closestX = 2f;
            }else{
                closestX = 6f;
            }
        }
        if(backwards == false) newTarget = new Vector3 (closestX ,agent.transform.position.y,target.position.z);
        try{
        if(backwards == true) newTarget =  new Vector3(target.position.x ,agent.transform.position.y,target.position.z);
        }
        catch{
            Storage.numberSeatsTaken = Storage.numberSeats;
        }
        if (Vector3.Distance(agent.transform.position,  newTarget) > 1f){
            if(backwards == false) agent.GetComponent<NavMeshAgent>().SetDestination(new Vector3 (closestX ,agent.transform.position.y,target.position.z ));
            else{
                agent.GetComponent<NavMeshAgent>().SetDestination(newTarget);
            }
        }
        else{
            if(backwards == true){
                RemoveAgentBack();
            }
            else{
            if (Wait()){
                RemoveAgent();
            }
            }
        }
    }
}
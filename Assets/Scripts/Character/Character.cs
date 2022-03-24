using UnityEngine;
using UnityEngine.Events;
public abstract class Character {

    public bool backwards;
    public float speed {get;set;}
    public int Id {get;set;}
    public GameObject agent;
    public Transform target;
    public float timeWait;
    public float force;
    public abstract void StartMove(Transform _target, GameObject _agent);

    public bool IsWalking;

    public CharacterImplement characterImplement;
    public UnityAction movementAction;
    public bool Wait(){
        if (timeWait <= 0){
            return true;
        }else{
            timeWait -= Time.deltaTime;
            return false;
        }
    }
    public void RemoveAgent(){
        characterImplement.DeleteAgent();
        target.GetComponent<Renderer>().material.color = Color.Lerp(Color.green,Color.black,Storage.colorOffset);
        Storage.colorOffset += 0.007f;
        Storage.numberSeatsTaken ++;
        Storage.agentScripts.Remove(this);
        movementManager.agentsMovement.RemoveListener(movementAction);
        return;
    }

    public void RemoveAgentBack(){
        try{
            Storage.AgentPositions.Remove(agent.transform);
            characterImplement.DeleteAgent();
            Storage.AgentSeats[Id].GetComponent<Renderer>().material.color = Color.Lerp(Color.red,Color.white,Storage.colorOffset);
            Storage._numberSeats += 1;
            Storage.colorOffset += 0.007f;
            Storage.numberSeatsTaken ++;
            Storage.agentScripts.Remove(this);
            movementManager.agentsMovement.RemoveListener(movementAction);
            return;
        }
        catch{
            Storage.numberSeatsTaken = Storage.numberSeats;
        }
    }
}
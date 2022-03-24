using UnityEngine;
using UnityEngine.Events;
public class movementManager : MonoBehaviour {
    public static UnityEvent agentsMovement = new UnityEvent();
    void Start(){
    }

    void Update(){
        if (agentsMovement != null){
            agentsMovement.Invoke();
        }
    }
}
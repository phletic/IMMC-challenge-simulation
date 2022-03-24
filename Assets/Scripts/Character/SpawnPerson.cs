using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerson : MonoBehaviour
{

    public bool start;
    public GameObject human;
    public int IdDispense = 0;

    public SeatChooser[] chooseTypes = {new RandomSeat(), new BackToFrontSeat(), new FrontToBack(), new WilMA(), new SteffenPerfect(), new ReversePyramidMethod()};
    public SeatChooser _seatChooser;
    public Character characterType = new NarrowBody_CharacterController();

    Character currentCharacter;

    public float timeBetweenEachSpawn;
    public float timeToStowOneBag;
    public float timeForAgentToGetUpFromSeat;
    bool ShouldSpawn = true;
    [Range(0,1)]
    public float percentageNotFollowingRule;

    public int minBags;
    public int maxBags;

    public Transform seatHolder;

    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        _seatChooser = chooseTypes[GameManager.SeatArrangementOption];
        currentCharacter = characterType;
        if (start){
            foreach(Transform child in seatHolder){
                Storage.SeatArrangement.Add(child);
            }
            StartCoroutine(Spawn());
        }
        Debug.Log(Storage.SeatArrangement.Count);
    }

    void Update(){
        if(Physics.Raycast(transform.position-new Vector3(0,10,0),transform.TransformDirection(Vector3.up),100f))
        {
            Debug.DrawRay(transform.position-new Vector3(0,10,0),transform.TransformDirection(Vector3.up)*100f, Color.green);
            ShouldSpawn = false;
        }
        else{
            Debug.DrawRay(transform.position-new Vector3(0,10,0),transform.TransformDirection(Vector3.up)*100f,Color.red);
            ShouldSpawn = true;
        }
    }

    int ChooseNumberBag(){
        return rnd.Next(minBags,maxBags);
    }

    bool isWrongSeat(){
        float n = (float)rnd.NextDouble();
        return  n<percentageNotFollowingRule ? true : false;
    }
    float numberSpawned;
    public IEnumerator Spawn(){

        while (true){

            yield return new WaitForSeconds(timeBetweenEachSpawn);
            if(ShouldSpawn == true){
                GameObject clone = Instantiate(human,transform.position,Quaternion.identity);
                CharacterImplement cloneScript = clone.GetComponent<CharacterImplement>();
                cloneScript.currentCharacter = currentCharacter;
                cloneScript.numberOfBags = ChooseNumberBag();
                cloneScript.seatChooser = _seatChooser;
                Storage.agentScripts.Add(cloneScript.currentCharacter);
                cloneScript.Initialise(IdDispense, timeToStowOneBag, timeForAgentToGetUpFromSeat, isWrongSeat(), false);
                characterType = new NarrowBody_CharacterController();
                currentCharacter = characterType;
                numberSpawned ++;
                IdDispense ++;
            }
            if(numberSpawned == Storage.numberSeats){
                break;
            }
        }
    }

    public IEnumerator Disembark(){
        GoSpawn gs = new GoSpawn();
        gs.spawn = this.transform;
        IdDispense = 0;
        while (true)
        {
            if(Storage.OccupiedSeats[IdDispense].y == 0){
                break;
            }
            yield return new WaitForSeconds(0.2f);
            ShouldSpawn = true;
            for (int i = 0; i < Storage.AgentPositions.Count; i++)
            {
                if(Vector3.Distance(Storage.AgentPositions[i].position, new Vector3(3,1,Storage.OccupiedSeats[IdDispense].y)) < 1f){
                    ShouldSpawn = false;
                }
            }
            if(ShouldSpawn){
            GameObject clone = Instantiate(human, new Vector3 (3,1,Storage.OccupiedSeats[IdDispense].y) , Quaternion.identity);
            CharacterImplement cloneScript = clone.GetComponent<CharacterImplement>();
            cloneScript.currentCharacter = currentCharacter;
            cloneScript.numberOfBags = ChooseNumberBag();
            cloneScript.seatChooser = gs;
            cloneScript.Initialise(IdDispense, timeToStowOneBag, timeForAgentToGetUpFromSeat, isWrongSeat(), true);
            characterType = new NarrowBody_CharacterController();
            Storage.AgentPositions.Add(clone.transform);
            Storage.agentScripts.Add(cloneScript.currentCharacter);
            currentCharacter = characterType;
            numberSpawned ++;
            IdDispense ++;  
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPerson_TETA : MonoBehaviour
{

    public bool start;
    public GameObject human;
    public int IdDispense = 0;

    public SeatChooser[] chooseTypes = { new RandomSeat(), new BackToFrontSeat(), new FrontToBack(), new Wilma_TETA(), new SteffenPerfect__TETA(), new RPM_TETA() };
    public SeatChooser _seatChooser;
    public Character characterType = new TETA_CC();

    Character currentCharacter;

    public float timeBetweenEachSpawn;
    public float timeToStowOneBag;
    public float timeForAgentToGetUpFromSeat;
    bool ShouldSpawn = true;
    [Range(0, 1)]
    public float percentageNotFollowingRule;

    public int minBags;
    public int maxBags;

    public Transform seatHolder;

    public Transform AgentParent;

    System.Random rnd = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        _seatChooser = chooseTypes[GameManager.SeatArrangementOption];
        currentCharacter = characterType;
        if (start)
        {
            foreach (Transform child in seatHolder)
            {
                Storage.SeatArrangement.Add(child);
            }
            StartCoroutine(Spawn());
        }
        Debug.Log(Storage.SeatArrangement.Count);
    }

    void Update()
    {
        if (Physics.Raycast(transform.position - new Vector3(0, 10, 0), transform.TransformDirection(Vector3.up), 100f))
        {
            Debug.DrawRay(transform.position - new Vector3(0, 10, 0), transform.TransformDirection(Vector3.up) * 100f, Color.green);
            ShouldSpawn = false;
        }
        else
        {
            Debug.DrawRay(transform.position - new Vector3(0, 10, 0), transform.TransformDirection(Vector3.up) * 100f, Color.red);
            ShouldSpawn = true;
        }
    }

    int ChooseNumberBag()
    {
        return rnd.Next(minBags, maxBags);
    }

    bool isWrongSeat()
    {
        float n = (float)rnd.NextDouble();
        return n < percentageNotFollowingRule ? true : false;
    }
    float numberSpawned;
    public IEnumerator Spawn()
    {

        while (true)
        {

            yield return new WaitForSeconds(timeBetweenEachSpawn);
            if (ShouldSpawn == true)
            {
                GameObject clone = Instantiate(human, transform.position, Quaternion.identity);
                CharacterImplement cloneScript = clone.GetComponent<CharacterImplement>();
                cloneScript.currentCharacter = currentCharacter;
                cloneScript.numberOfBags = ChooseNumberBag();
                cloneScript.seatChooser = _seatChooser;
                cloneScript.Initialise(IdDispense, timeToStowOneBag, timeForAgentToGetUpFromSeat, isWrongSeat(), false);
                Storage.agentScripts.Add(cloneScript.currentCharacter);
                characterType = new TETA_CC();
                currentCharacter = characterType;
                numberSpawned++;
                IdDispense ++;
            }
            if (numberSpawned == Storage.numberSeats)
            {
                break;
            }
        }
    }



    public IEnumerator Disembark()
    {
        int Offset = 0;
        GoSpawn gs = new GoSpawn();
        gs.spawn = this.transform;
        IdDispense = 0;
        while (true)
        {
            Debug.Log(Storage.OccupiedSeats.Count);
            float closestX = 0;
            if(Storage.OccupiedSeats[Offset].x >= 1 && Storage.OccupiedSeats[Offset].x <= 5){
                if(Storage.OccupiedSeats[Offset].y >= 0 && Storage.OccupiedSeats[Offset].y <= 3)closestX = 2f;
                else{
                    closestX = 5f;   
                }
            }
            if((Storage.OccupiedSeats[Offset].x == 7) ){
                if(Storage.OccupiedSeats[Offset].y == 0 || Storage.OccupiedSeats[Offset].y == 1){
                    closestX = 2f;
                }
                else{
                    closestX = 6f;
                }
            }
            if(Storage.OccupiedSeats[Offset].x >= 8 && Storage.OccupiedSeats[Offset].y <= 19){
                if(Storage.OccupiedSeats[Offset].y >= 0 && Storage.OccupiedSeats[Offset].y <=3){
                    closestX = 2f;
                }else{
                    closestX = 6f;
                }
            }
            if((Storage.OccupiedSeats[Offset].x == 22) ){
                if(Storage.OccupiedSeats[Offset].y == 0 || Storage.OccupiedSeats[Offset].y == 1){
                    closestX = 2f;
                }
                else{
                    closestX = 6f;
                }
            }
            if(Storage.OccupiedSeats[Offset].x >= 24 && Storage.OccupiedSeats[Offset].y <= 43){
                if(Storage.OccupiedSeats[Offset].y >= 0 && Storage.OccupiedSeats[Offset].y <=3){
                    closestX = 2f;
                }else{
                    closestX = 6f;
                }
            }

            yield return new WaitForSeconds(0.2f);
            ShouldSpawn = true;
            for (int i = 0; i < Storage.AgentPositions.Count; i++)
            {
                try{
                if (Vector3.Distance(Storage.AgentPositions[i].position, new Vector3(closestX, 1, Storage.OccupiedSeats[Offset].y)) < 1f)
                {
                    ShouldSpawn = false;
                }}
                catch{
                    Storage.numberSeatsTaken = Storage.numberSeats;
                }
            }
            if (ShouldSpawn)
            {
                GameObject clone = Instantiate(human, new Vector3(closestX, 1, Storage.OccupiedSeats[Offset].y), Quaternion.identity);
                clone.transform.parent = AgentParent;
                Storage.OccupiedSeats.RemoveAt(Offset);
                Debug.Log(Storage.OccupiedSeats.Count);
                
                CharacterImplement cloneScript = clone.GetComponent<CharacterImplement>();
                cloneScript.currentCharacter = currentCharacter;
                cloneScript.numberOfBags = ChooseNumberBag();
                cloneScript.seatChooser = gs;
                Storage.agentScripts.Add(cloneScript.currentCharacter);
                cloneScript.Initialise(IdDispense, timeToStowOneBag, timeForAgentToGetUpFromSeat, isWrongSeat(), true);
                characterType = new TETA_CC();
                Storage.AgentPositions.Add(clone.transform);
                currentCharacter = characterType;
                numberSpawned++;
                IdDispense++;
                Offset = 0;
            }
            else
            {
                Offset += 1;
                if (Offset + 1 == Storage.OccupiedSeats.Count)
                {
                    Offset = 0;
                }
            }
        }
    }
}
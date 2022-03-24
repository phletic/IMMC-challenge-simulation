using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class SpawnPerson_FlyingWing : MonoBehaviour
{

    public bool start;
    public GameObject human;
    public int IdDispense = 0;

    public SeatChooser[] chooseTypes = { new RandomSeat(), new BackToFrontSeat(), new FrontToBack(), new WilMA(), new SteffenPerfect(), new ReversePyramidMethod_FlyingWing() };
    public SeatChooser _seatChooser;
    public Character characterType = new FlyingWing_CC();

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
                Storage.agentScripts.Add(cloneScript.currentCharacter);
                cloneScript.Initialise(IdDispense, timeToStowOneBag, timeForAgentToGetUpFromSeat, isWrongSeat(), false);
                characterType = new FlyingWing_CC();
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


    int[] Destination = { 3, 10, 17, 24 };
    public IEnumerator Disembark()
    {
        int Offset = 0;
        GoSpawn gs = new GoSpawn();
        gs.spawn = this.transform;
        IdDispense = 0;
        while (true)
        {
            Debug.Log(Storage.OccupiedSeats.Count);
            int closestX = Destination.OrderBy(v => Mathf.Abs((int)v - Storage.OccupiedSeats[Offset].x)).First();
            yield return new WaitForSeconds(0.2f);
            ShouldSpawn = true;
            for (int i = 0; i < Storage.AgentPositions.Count; i++)
            {
                try{
                if (Vector3.Distance(Storage.AgentPositions[i].position, new Vector3(closestX, 1, Storage.OccupiedSeats[Offset].y)) < 1f)
                {
                    ShouldSpawn = false;
                }
                }
                catch{
                    continue;
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
                cloneScript.Initialise(IdDispense, timeToStowOneBag, timeForAgentToGetUpFromSeat, isWrongSeat(), true);
                characterType = new FlyingWing_CC();
                Storage.agentScripts.Add(cloneScript.currentCharacter);
                Storage.AgentPositions.Add(clone.transform);
                currentCharacter = characterType;
                numberSpawned++;
                IdDispense++;
                Offset = 0;
            }
            else{
                Offset+=1;
                if(Offset + 1 == Storage.OccupiedSeats.Count){
                    Offset = 0;
                }
            }
        }
    }
}
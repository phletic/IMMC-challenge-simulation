using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateSeatRows : MonoBehaviour
{

    public int typePlane;
    public PlaneDimensionController planeDimensionController;
    public IsSeat[] typeArrangements = {new NarrowBodyPlaneSeats(), new FlyingWingPlaneSeat()};

    public IsSeat _isSeat;
    public GameObject seatPrefab;
    public static List<GameObject> SeatArrangement; 

    public SpawnPerson _spawnPerson;

    [Range(0,1)]
    public float percentageSeatsMissing;
    // Start is called before the first frame update


    void Start()
    {
        _isSeat = typeArrangements[typePlane];
        for (int y = 0; y < planeDimensionController.length; y++)
        {
            for (int x = 0; x < planeDimensionController.width; x++)
            {
                if (_isSeat.isSeat(x,y) == true){
                    GameObject clone = Instantiate(seatPrefab, new Vector3(x,0.5f,y), Quaternion.identity);
                    Storage.numberSeats ++;
                    Transform cloneT = clone.GetComponent<Transform>();
                    cloneT.parent = transform;
                    Storage.SeatArrangement.Add(cloneT);
                }
            }
        }
        System.Random rnd = new System.Random();
        int NumberSeatsMissing = (int)Mathf.Ceil(percentageSeatsMissing * (float)Storage.SeatArrangement.Count);
        for (int i = 0; i < NumberSeatsMissing; i++)
        {
            int Number = rnd.Next(0, Storage.SeatArrangement.Count - 1);
            Destroy(Storage.SeatArrangement[Number].gameObject);
            Storage.SeatArrangement.RemoveAt(Number);
            Storage.numberSeats -= 1;
        }

        StartCoroutine(_spawnPerson.Spawn());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
using UnityEngine;

public class CharacterImplement : MonoBehaviour {
    [HideInInspector]
    public Character currentCharacter;

    Transform target;

    [HideInInspector]
    public SeatChooser seatChooser;

    public int numberOfBags;

    public Vector3 TargetVector;

    public int id;
    public float CurrentTime;
    public void Initialise(int Id, float t1, float t2, bool WrongSeat, bool backwards){
        id= Id;
        currentCharacter.Id = Id;
        currentCharacter.backwards = backwards;
        target = seatChooser.GiveSeat(Id, WrongSeat);
        target.GetComponent<Renderer>().material.color = Color.blue;
        TargetVector = target.position;
        if(!backwards) Storage.AgentSeats.Add(target);
        int maxOccupied = 0;
        for (int i = 0; i < Storage.OccupiedSeats.Count; i++)
        {
            if (Storage.OccupiedSeats[i].y == target.position.y){
                if((Storage.OccupiedSeats[i].x >= 4 && target.position.x >= 4 && Storage.OccupiedSeats[i].x <= 4 && target.position.x <=6)
                    ||
                    (Storage.OccupiedSeats[i].x >= 11 && target.position.x >= 11 && Storage.OccupiedSeats[i].x <= 13 && target.position.x <=13)
                    ||
                    (Storage.OccupiedSeats[i].x >= 18 && target.position.x >= 18 && Storage.OccupiedSeats[i].x <= 20 && target.position.x <=20)
                    ||
                    (Storage.OccupiedSeats[i].x >= 25 && target.position.x >= 25 && Storage.OccupiedSeats[i].x <= 27 && target.position.x <=27)
                ){
                    if(target.position.x > Storage.OccupiedSeats[i].x){
                        maxOccupied ++;
                    }
                    else{
                        continue;
                    }
                }
                if((Storage.OccupiedSeats[i].x <= 2 && target.position.x <= 2)
                    ||
                    (Storage.OccupiedSeats[i].x >= 7 && target.position.x >= 7 && Storage.OccupiedSeats[i].x <= 9 && target.position.x <=9)
                    ||
                    (Storage.OccupiedSeats[i].x >= 14 && target.position.x >= 14 && Storage.OccupiedSeats[i].x <= 16 && target.position.x <=16)
                    ||
                    (Storage.OccupiedSeats[i].x >= 21 && target.position.x >= 21 && Storage.OccupiedSeats[i].x <= 23 && target.position.x <=23)
                )
                {
                    if(target.position.x < Storage.OccupiedSeats[i].x){
                        maxOccupied ++;
                    }
                    else{
                        continue;
                    }
                }
            }else{
                continue;
            }
        }
        Storage.OccupiedSeats.Add(new Vector2(target.position.x,target.position.z));
        //DeleteAgent();
        currentCharacter.timeWait += maxOccupied * t2 / Time.timeScale;
        currentCharacter.timeWait += numberOfBags * t1 / Time.timeScale;
        currentCharacter.characterImplement = this;
        CurrentTime = currentCharacter.timeWait;
        currentCharacter.StartMove(target,this.gameObject);
    }

    public void DeleteAgent(){
        Destroy(this.gameObject);
    }
}
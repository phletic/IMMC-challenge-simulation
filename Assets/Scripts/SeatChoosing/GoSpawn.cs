using UnityEngine;
public class GoSpawn : SeatChooser
{

    public GoSpawn() { }
    public Transform spawn;
    public override Transform GiveSeat(int id, bool WrongSeat)
    {
        return spawn;
    }
}
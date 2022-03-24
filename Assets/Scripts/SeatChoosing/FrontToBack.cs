using UnityEngine;
public class FrontToBack : SeatChooser
{

    public FrontToBack() { }
    public override Transform GiveSeat(int id, bool WrongSeat)
    {
        Transform seat = Storage.SeatArrangement[0];
        if (WrongSeat)
        {
            seat = Storage.SeatArrangement[rnd.Next(0, Storage.SeatArrangement.Count - 1)];
            Storage.SeatArrangement.Remove(seat);
            return seat;
        }
        else
        {
            Storage.SeatArrangement.Remove(seat);
            return seat;
        }
    }
}
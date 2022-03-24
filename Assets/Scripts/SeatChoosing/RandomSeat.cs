using UnityEngine;
public class RandomSeat : SeatChooser
{

    public RandomSeat() { }
    public override Transform GiveSeat(int id, bool WrongSeat)
    {
        int result = rnd.Next(0, Storage.SeatArrangement.Count - 1);
        Transform seat = Storage.SeatArrangement[result];
        Storage.SeatArrangement.RemoveAt(result);
        return seat;
    }
}
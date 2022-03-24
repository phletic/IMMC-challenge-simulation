using UnityEngine;
using System.Collections.Generic;
public class ReversePyramidMethod : SeatChooser
{

    List<Transform>[] Order = new List<Transform>[4];
    bool Generated = false;
    public ReversePyramidMethod() { }
    public override Transform GiveSeat(int id, bool WrongSeat)
    {
        if (Generated == false)
        {
            GenerateOrder();
            Generated = true;
        }
        for (int i = 0; i < Order.Length; i++)
        {
            if (Order[i].Count > 0)
            {
                if (WrongSeat)
                {
                    Transform[] tmpSeat = Order[i].ToArray();
                    Order[i] = Order[i + 1];
                    Order[i + 1] = new List<Transform>(tmpSeat);
                }
                Transform res = Order[i][Order[i].Count - 1];
                Order[i].Remove(res);
                return res;
            }
        }
        return null;
    }

    void GenerateOrder()
    {
        for (int i = 0; i < Order.Length; i++)
        {
            Order[i] = new List<Transform>();
        }
        for (int i = 0; i < Storage.SeatArrangement.Count; i++)
        {

            Transform seat = Storage.SeatArrangement[i];
            Vector3 pos = seat.position;

            if ((pos.x == 0 || pos.x == 6) && pos.z > 16)
            {
                Order[0].Add(seat);
            }
            else if (((pos.x == 0 || pos.x == 6) && pos.z <= 16) || ((pos.x == 1 || pos.x == 5) && pos.z > 16))
            {
                Order[1].Add(seat);
            }
            else if (((pos.x == 1 || pos.x == 5) && pos.z <= 16) || ((pos.x == 2 || pos.x == 4) && pos.z > 16))
            {
                Order[2].Add(seat);
            }
            else
            {
                Order[3].Add(seat);
            }
        }
    }
}
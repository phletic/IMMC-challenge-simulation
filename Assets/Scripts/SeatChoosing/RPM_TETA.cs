using UnityEngine;
using System.Collections.Generic;
public class RPM_TETA : SeatChooser
{

    List<Transform>[] Order = new List<Transform>[5];
    bool Generated = false;
    public RPM_TETA() { }
    public override Transform GiveSeat(int id, bool WrongSeat)
    {
        if (Generated == false)
        {
            GenerateOrder();
            Generated = true;
        }
        if (WrongSeat)
        {
            int firstLayer = getNonEmptyOrder(4, Order);
            int secondLayer = rnd.Next(0, Order[firstLayer].Count - 1);
            Transform res = Order[firstLayer][secondLayer];
            Order[firstLayer].Remove(res);
            return res;
        }
        for (int i = 0; i < Order.Length; i++)
        {
            if (Order[i].Count > 0)
            {
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

            if ((pos.x == 0 || pos.x == 8) && pos.z > 22)
            {
                Order[0].Add(seat);
            }
            else if (((pos.x == 0 || pos.x == 8) && pos.z <= 22) || ((pos.x == 1 || pos.x == 7) && pos.z > 22))
            {
                Order[1].Add(seat);
            }
            else if (((pos.x == 1 || pos.x == 7) && pos.z <= 22) || ((pos.x == 2 || pos.x == 6) && pos.z > 22))
            {
                Order[2].Add(seat);
            }
            else if (((pos.x == 2 || pos.x == 6) && pos.z <= 22) || ((pos.x == 3 || pos.x == 5) && pos.z > 22))
            {
                Order[4].Add(seat);
            }
            else
            {
                Order[3].Add(seat);
            }
        }
    }
}
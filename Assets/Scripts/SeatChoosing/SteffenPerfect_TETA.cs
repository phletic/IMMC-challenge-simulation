using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class SteffenPerfect__TETA : SeatChooser
{

    public SteffenPerfect__TETA() { }

    List<Transform>[] Order = new List<Transform>[14];
    bool Generated = false;

    public override Transform GiveSeat(int id, bool WrongSeat)
    {
        if (Generated == false)
        {
            GenerateOrder();
            Generated = true;
        }
        if (WrongSeat)
        {
            int firstLayer = getNonEmptyOrder(12, Order);
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
            if (pos.x == 0 && pos.z % 2 == 0)
            {
                Order[0].Add(seat);
            }
            else if (pos.x == 8 && pos.z % 2 == 0)
            {
                Order[1].Add(seat);
            }


            else if (pos.x == 0 && (pos.z + 1) % 2 == 0)
            {
                Order[2].Add(seat);
            }
            else if (pos.x == 8 && (pos.z + 1) % 2 == 0)
            {
                Order[3].Add(seat);
            }


            else if (pos.x == 1 && pos.z % 2 == 0)
            {
                Order[4].Add(seat);
            }
            else if (pos.x == 7 && pos.z % 2 == 0)
            {
                Order[5].Add(seat);
            }
            else if (pos.x == 1 && (pos.z + 1) % 2 == 0)
            {
                Order[4].Add(seat);
            }
            else if (pos.x == 7 && (pos.z + 1) % 2 == 0)
            {
                Order[5].Add(seat);
            }

            else if (pos.x == 6 && (pos.z + 1) % 2 == 0)
            {
                Order[6].Add(seat);
            }
            else if (pos.x == 6 && (pos.z) % 2 == 0)
            {
                Order[7].Add(seat);
            }


            else if (pos.x == 4 && (pos.z + 1) % 2 == 0)
            {
                Order[8].Add(seat);
            }
            else if (pos.x == 4 && pos.z % 2 == 0)
            {
                Order[9].Add(seat);
            }

            else if (pos.x == 3 && (pos.z + 1) % 2 == 0)
            {
                Order[10].Add(seat);
            }
            else if (pos.x == 5 && (pos.z + 1) % 2 == 0)
            {
                Order[11].Add(seat);
            }


            else if (pos.x == 3 && pos.z % 2 == 0)
            {
                Order[12].Add(seat);
            }
            else if (pos.x == 5 && pos.z % 2 == 0)
            {
                Order[13].Add(seat);
            }
        }

    }
}
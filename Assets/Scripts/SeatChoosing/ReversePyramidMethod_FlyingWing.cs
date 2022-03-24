using UnityEngine;
using System.Collections.Generic;
public class ReversePyramidMethod_FlyingWing : SeatChooser
{

    List<Transform>[] Order = new List<Transform>[4];
    bool Generated = false;
    public ReversePyramidMethod_FlyingWing() { }
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

            if ((pos.x == 0 || pos.x == 6) && pos.z > 7)
            {
                Order[0].Add(seat);
            }
            else if (((pos.x == 0 || pos.x == 6) && pos.z <= 7) || ((pos.x == 1 || pos.x == 5) && pos.z > 7))
            {
                Order[1].Add(seat);
            }
            else if (((pos.x == 1 || pos.x == 5) && pos.z <= 7) || ((pos.x == 2 || pos.x == 4) && pos.z > 7))
            {
                Order[2].Add(seat);
            }
            else if ((pos.x == 7 || pos.x == 13) && pos.z > 7)
            {
                Order[0].Add(seat);
            }
            else if (((pos.x == 7 || pos.x == 13) && pos.z <= 7) || ((pos.x == 8 || pos.x == 12) && pos.z > 7))
            {
                Order[1].Add(seat);
            }
            else if (((pos.x == 8 || pos.x == 12) && pos.z <= 7) || ((pos.x == 9 || pos.x == 11) && pos.z > 7))
            {
                Order[2].Add(seat);
            }

            else if ((pos.x == 14 || pos.x == 20) && pos.z > 7)
            {
                Order[0].Add(seat);
            }
            else if (((pos.x == 14 || pos.x == 20) && pos.z <= 7) || ((pos.x == 15 || pos.x == 19) && pos.z > 7))
            {
                Order[1].Add(seat);
            }
            else if (((pos.x == 15 || pos.x == 19) && pos.z <= 7) || ((pos.x == 16 || pos.x == 18) && pos.z > 7))
            {
                Order[2].Add(seat);
            }

            else if ((pos.x == 21 || pos.x == 27) && pos.z > 7)
            {
                Order[0].Add(seat);
            }
            else if (((pos.x == 21 || pos.x == 27) && pos.z <= 7) || ((pos.x == 22 || pos.x == 26) && pos.z > 7))
            {
                Order[1].Add(seat);
            }
            else if (((pos.x == 22 || pos.x == 26) && pos.z <= 7) || ((pos.x == 23 || pos.x == 25) && pos.z > 7))
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
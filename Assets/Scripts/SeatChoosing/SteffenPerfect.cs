using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class SteffenPerfect : SeatChooser
{

    public SteffenPerfect() { }

    List<Transform>[] Order = new List<Transform>[12];
    bool Generated = false;

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
                if(WrongSeat){
                    Transform[] tmpSeat = Order[i].ToArray();
                    Order[i] = Order[i+1];
                    Order[i+1] = new List<Transform>(tmpSeat);
                }
                Transform res = Order[i][Order[i].Count - 1];
                Order[i].Remove(res);
                return res;
            }
        }
        Debug.Log(Order.Length-1);
        return Order[Order.Length-1][Order[Order.Length-1].Count-1];
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
            else if (pos.x == 6 && pos.z % 2 == 0)
            {
                Order[1].Add(seat);
            }


            else if (pos.x == 0 && (pos.z + 1) % 2 == 0)
            {
                Order[2].Add(seat);
            }
            else if (pos.x == 6 && (pos.z + 1) % 2 == 0)
            {
                Order[3].Add(seat);
            }


            else if (pos.x == 1 && pos.z % 2 == 0)
            {
                Order[4].Add(seat);
            }
            else if (pos.x == 5 && pos.z % 2 == 0)
            {
                Order[5].Add(seat);
            }


            else if (pos.x == 1 && (pos.z + 1) % 2 == 0)
            {
                Order[6].Add(seat);
            }
            else if (pos.x == 5 && (pos.z + 1) % 2 == 0)
            {
                Order[7].Add(seat);
            }


            else if (pos.x == 2 && pos.z % 2 == 0)
            {
                Order[8].Add(seat);
            }
            else if (pos.x == 4 && pos.z % 2 == 0)
            {
                Order[9].Add(seat);
            }


            else if (pos.x == 2 && (pos.z + 1) % 2 == 0)
            {
                Order[10].Add(seat);
            }
            else if (pos.x == 4 && (pos.z + 1) % 2 == 0)
            {
                Order[11].Add(seat);
            }





            if (pos.x == 7 && pos.z % 2 == 0)
            {
                Order[0].Add(seat);
            }
            else if (pos.x == 13 && pos.z % 2 == 0)
            {
                Order[1].Add(seat);
            }


            else if (pos.x == 7 && (pos.z + 1) % 2 == 0)
            {
                Order[2].Add(seat);
            }
            else if (pos.x == 13 && (pos.z + 1) % 2 == 0)
            {
                Order[3].Add(seat);
            }


            else if (pos.x == 8 && pos.z % 2 == 0)
            {
                Order[4].Add(seat);
            }
            else if (pos.x == 12 && pos.z % 2 == 0)
            {
                Order[5].Add(seat);
            }


            else if (pos.x == 8 && (pos.z + 1) % 2 == 0)
            {
                Order[6].Add(seat);
            }
            else if (pos.x == 12 && (pos.z + 1) % 2 == 0)
            {
                Order[7].Add(seat);
            }


            else if (pos.x == 9 && pos.z % 2 == 0)
            {
                Order[8].Add(seat);
            }
            else if (pos.x == 11 && pos.z % 2 == 0)
            {
                Order[9].Add(seat);
            }


            else if (pos.x == 9 && (pos.z + 1) % 2 == 0)
            {
                Order[10].Add(seat);
            }
            else if (pos.x == 11 && (pos.z + 1) % 2 == 0)
            {
                Order[1].Add(seat);
            }




            if (pos.x == 14 && pos.z % 2 == 0)
            {
                Order[0].Add(seat);
            }
            else if (pos.x == 20 && pos.z % 2 == 0)
            {
                Order[1].Add(seat);
            }


            else if (pos.x == 14 && (pos.z + 1) % 2 == 0)
            {
                Order[2].Add(seat);
            }
            else if (pos.x == 20 && (pos.z + 1) % 2 == 0)
            {
                Order[3].Add(seat);
            }


            else if (pos.x == 15 && pos.z % 2 == 0)
            {
                Order[4].Add(seat);
            }
            else if (pos.x == 19 && pos.z % 2 == 0)
            {
                Order[5].Add(seat);
            }


            else if (pos.x == 15 && (pos.z + 1) % 2 == 0)
            {
                Order[6].Add(seat);
            }
            else if (pos.x == 19 && (pos.z + 1) % 2 == 0)
            {
                Order[7].Add(seat);
            }


            else if (pos.x == 16 && pos.z % 2 == 0)
            {
                Order[8].Add(seat);
            }
            else if (pos.x == 18 && pos.z % 2 == 0)
            {
                Order[9].Add(seat);
            }


            else if (pos.x == 16 && (pos.z + 1) % 2 == 0)
            {
                Order[10].Add(seat);
            }
            else if (pos.x == 18 && (pos.z + 1) % 2 == 0)
            {
                Order[11].Add(seat);
            }





            if (pos.x == 21 && pos.z % 2 == 0)
            {
                Order[0].Add(seat);
            }
            else if (pos.x == 27 && pos.z % 2 == 0)
            {
                Order[1].Add(seat);
            }


            else if (pos.x == 21 && (pos.z + 1) % 2 == 0)
            {
                Order[2].Add(seat);
            }
            else if (pos.x == 27 && (pos.z + 1) % 2 == 0)
            {
                Order[3].Add(seat);
            }


            else if (pos.x == 22 && pos.z % 2 == 0)
            {
                Order[4].Add(seat);
            }
            else if (pos.x == 26 && pos.z % 2 == 0)
            {
                Order[5].Add(seat);
            }


            else if (pos.x == 22 && (pos.z + 1) % 2 == 0)
            {
                Order[6].Add(seat);
            }
            else if (pos.x == 26 && (pos.z + 1) % 2 == 0)
            {
                Order[7].Add(seat);
            }


            else if (pos.x == 23 && pos.z % 2 == 0)
            {
                Order[8].Add(seat);
            }
            else if (pos.x == 25 && pos.z % 2 == 0)
            {
                Order[9].Add(seat);
            }


            else if (pos.x == 23 && (pos.z + 1) % 2 == 0)
            {
                Order[10].Add(seat);
            }
            else if (pos.x == 25 && (pos.z + 1) % 2 == 0)
            {
                Order[11].Add(seat);
            }
        }

    }
}
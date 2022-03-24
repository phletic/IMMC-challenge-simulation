using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SeatChooser
{
    public System.Random rnd = new System.Random();
    public abstract Transform GiveSeat(int id, bool WrongSeat);

    public int getNonEmptyOrder(int n, List<Transform>[] Order)
    {

        int res = rnd.Next(0, n<0 ? 1 : n-1);
        if (Order[res].Count == 0)
        {
            return res+1;
        }
        else
        {
            return res;
        }
    }
}

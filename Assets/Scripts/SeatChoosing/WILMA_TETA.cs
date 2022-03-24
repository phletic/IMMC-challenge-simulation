using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class Wilma_TETA : SeatChooser
{

    public Wilma_TETA() { }
    List<Transform> Window = new List<Transform>();

    List<Transform> Middle = new List<Transform>();

    List<Transform> Aisle = new List<Transform>();
    public override Transform GiveSeat(int id, bool WrongSeat)
    {
        if (Window.Count == 0 && Middle.Count == 0 && Aisle.Count == 0)
        {
            GenerateOrder();
        }
        if (Window.Count != 0)
        {
            Transform seat = Window[Window.Count - 1];
            if (WrongSeat)
            {
                seat = Window[rnd.Next(0, Window.Count - 1)];
            }
            Window.Remove(seat);
            return seat;
        }
        if (Middle.Count != 0)
        {
            Transform seat = Middle[Middle.Count - 1];
            if (WrongSeat)
            {
                seat = Middle[rnd.Next(0, Window.Count - 1)];
            }
            Middle.Remove(seat);
            return seat;
        }
        if (Aisle.Count != 0)
        {
            Transform seat = Aisle[Aisle.Count - 1];
            if (WrongSeat)
            {
                seat = Aisle[rnd.Next(0, Window.Count - 1)];
            }
            Aisle.Remove(seat);
            return seat;
        }
        else
        {
            return null;
        }

    }

    void GenerateOrder()
    {
        for (int i = 0; i < Storage.SeatArrangement.Count; i++)
        {
            switch (Storage.SeatArrangement[i].position.x)
            {
                case 0:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 8:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 4:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 7:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 5:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 3:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 1:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 6:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
            }
        }
    }
}
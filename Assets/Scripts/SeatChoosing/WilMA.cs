using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class WilMA : SeatChooser
{

    public WilMA() { }
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
                seat = Middle[rnd.Next(0, Middle.Count - 1)];
            }
            Middle.Remove(seat);
            return seat;
        }
        if (Aisle.Count != 0)
        {
            Transform seat = Aisle[Aisle.Count - 1];
            if (WrongSeat)
            {
                seat = Aisle[rnd.Next(0, Aisle.Count - 1)];
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
                case 1:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 2:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;


                case 4:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 5:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 6:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 7:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 8:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 9:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;


                case 11:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 12:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 13:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 14:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 15:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 16:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;

                case 18:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 19:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 20:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 21:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
                case 22:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 23:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;

                case 25:
                    Aisle.Add(Storage.SeatArrangement[i]);
                    break;
                case 26:
                    Middle.Add(Storage.SeatArrangement[i]);
                    break;
                case 27:
                    Window.Add(Storage.SeatArrangement[i]);
                    break;
            }
        }
    }
}
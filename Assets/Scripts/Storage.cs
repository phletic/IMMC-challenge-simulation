using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public static class Storage
{
    public static int numberSeats = 0;

    public static bool simDone = false;

    public static float colorOffset = 0f;
    public static int numberSeatsTaken;
    public static List<Vector2> OccupiedSeats = new List<Vector2>();
    public static List<Transform> SeatArrangement = new List<Transform>();
    public static List<Transform> AgentPositions = new List<Transform>();

    public static List<Transform> AgentSeats = new List<Transform>();
    public static int _numberSeats = 0;

    public static List<Character> agentScripts = new List<Character>();
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testList : MonoBehaviour
{
    public Vector2[] Locations;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Locations = Storage.OccupiedSeats.ToArray();
    }
}

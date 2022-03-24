using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
public class GameManager : MonoBehaviour
{
    public float simSpeed;
    public float timeTaken = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = simSpeed;
    }

    [Space]
    [Header("0: Random Arrangement")]
    [Header("1: Back To Front")]
    [Header("2: Front To Back")]
    [Header("3: WilMA")]
    [Header("4: Steffen Perfect")]
    [Header("5: Reverse Pyramid")]
    [Space]
    public int _SeatArrangementOption;
    public static int SeatArrangementOption;

    public bool disembark;

    public SpawnPerson sp;

    public SpawnPerson_FlyingWing spf;

    public SpawnPerson_TETA spTETA;

    public Transform AgentParent;
    public int typePlane;

    public Transform entrance;
    public bool done = false;
    bool destroyParent;
    void Awake()
    {
        GameManager.SeatArrangementOption = _SeatArrangementOption;
        StartCoroutine(WriteFile());
    }

    IEnumerator WriteFile()
    {
        while (!done)
        {
            int numberCon = 0;
            foreach (Character c in Storage.agentScripts)
            {
                if (c.IsWalking == true)
                {
                    numberCon++;
                }
            }
            using (StreamWriter sw = File.AppendText("Assets/Data.txt"))
            {
                sw.WriteLine(timeTaken.ToString() + "\t" + numberCon);
            }
            yield return new WaitForSeconds(1f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Storage.numberSeatsTaken == Storage.numberSeats)
        {
            done = true;
            if (disembark)
            {
                done = false;
                Storage.colorOffset = 0f;
                disembark = false;
                destroyParent = true;
                timeTaken = 0;
                if (_SeatArrangementOption >= 3 && _SeatArrangementOption <= 5)
                {
                    Storage.OccupiedSeats.Reverse();
                    Storage.AgentSeats.Reverse();
                }
                Storage.numberSeatsTaken = 0;
                if (typePlane == 0)
                {
                    StartCoroutine(WriteFile());
                    StartCoroutine(sp.Disembark());
                }
                if (typePlane == 1)
                {
                    StartCoroutine(WriteFile());
                    StartCoroutine(spf.Disembark());
                }
                if (typePlane == 2)
                {
                    StartCoroutine(WriteFile());
                    StartCoroutine(spTETA.Disembark());
                }
            }
            else
            {
                if (typePlane == 1)
                {
                    StartCoroutine(Pause());
                }
                if (typePlane == 2)
                {
                    StartCoroutine(PauseT());
                }
                Debug.Log(timeTaken);
                if (destroyParent)
                {
                    Destroy(AgentParent.gameObject);
                    destroyParent = false;
                }
            }
        }
        else
        {
            timeTaken += Time.deltaTime * 5;
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(700f);
        foreach (Transform c in AgentParent)
        {
            Destroy(c.gameObject);
        }
    }

    IEnumerator PauseT()
    {
        while (Storage._numberSeats < 250) yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(8f);
        foreach (Transform c in AgentParent)
        {
            Destroy(c.gameObject);
        }
        Destroy(entrance);
    }
}

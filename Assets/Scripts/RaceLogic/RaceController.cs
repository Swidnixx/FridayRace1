using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceController : MonoBehaviour
{
    public static bool racePending;
    public static int totalLaps = 1;

    public int timer = 3;

    CheckpointController[] controllers;

    private void Start()
    {
        StartRace();
    }

    void StartRace()
    {
        controllers = FindObjectsOfType<CheckpointController>();
        InvokeRepeating( nameof(CountDown), 1, 1 );
    }

    void CountDown()
    {
        timer--;
        if(timer < 1)
        {
            CancelInvoke();
            racePending = true;
        }
    }

    private void LateUpdate()
    {
        int finishers = 0;

        foreach(var c in controllers)
        {
            if (c.Lap > totalLaps)
                finishers++;
        }

        if( finishers == controllers.Length )
        {
            FinishRace();
        }
    }

    private void FinishRace()
    {
        Debug.Log("Wyœcig zakoñczony");
        racePending = false;
    }
}

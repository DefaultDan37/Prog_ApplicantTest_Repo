using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopwatchBehaviour : C_Behaviour
{
    private bool isStopwatchTriggered = false;

    private Stopwatch stopwatch;

    public override void Init()
    {
        isStopwatchTriggered = true;
        stopwatch = new Stopwatch();
        c_Time = new C_Time();

        stopwatch.ToggleStopwatch(isStopwatchTriggered);
    }

    public override string DoBehaviour()
    {
        string time = "";

        if (isStopwatchTriggered == true)
        {
            stopwatch.Update();

            time = stopwatch.CurrentTime;
        }
        return time;
    }

    public override C_Time C_Update()
    {
        //Executes Init behaviour once
        if (doInit == true)
        {
            Init();
            doInit = false;
        }
        c_Time.SetTime(DoBehaviour());

        return c_Time;
    }


    public Stopwatch Stopwatch
    {
        get
        {
            return stopwatch;
        }
    }
}

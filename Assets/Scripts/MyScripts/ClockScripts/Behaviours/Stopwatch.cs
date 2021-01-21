using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Stopwatch : C_Time
{
    private bool isStopwatchStarted = false;

    private string timeZero = "0:00.00";

    // Reset the time on the Stopwatch to 0s --- Does NOT set "isStopwatchStarted" to false
    public void ResetStopwatch()
    {
        time = timeZero;
        hours = 0;
        minutes = 0;
        seconds = 0;
    }

    // Toggle the Stopwatch on and off
    public void ToggleStopwatch(bool condition)
    {
        isStopwatchStarted = condition;
    }

    public void Update()
    {
        if (isStopwatchStarted == true)
        {
            if (seconds < 60)
            {
                seconds += Time.deltaTime;

                Math.Truncate(seconds);

            }
            else
            {
               seconds = 0;

                if (minutes < 60)
                {
                    minutes++;
                }
                else
                {
                    hours++;
                }

            }

            time = $"{hours}:{minutes}.{seconds}";

        }
    }
}

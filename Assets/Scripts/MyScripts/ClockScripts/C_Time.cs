using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class C_Time
{
    private bool isMeridem = false;

    private string meridem;

    //-------------

    protected float seconds = 0;

    protected float minutes = 0;

    protected float hours = 0;

    protected string time;

    //------------

    private System.TimeSpan c_Time;

    public void SetTime(string nTime)
    {
        time = nTime;
    }


    public string GetSystemTime(bool is24HourNotation = false)
    {
        isMeridem = false;

        c_Time = System.DateTime.Now.TimeOfDay;

        seconds = (float)c_Time.Seconds;

        minutes = (float)c_Time.Minutes;

        hours = (float)c_Time.Hours;


        if (is24HourNotation != true)
        {
            isMeridem = true;

            if (hours > 12)
            {
                meridem = "PM";
                hours -= 12;
            }
            else
            {
                meridem = "AM";
            }

        }

       time = $"{hours} : {minutes}.{seconds}";

        if (isMeridem == true)
        {
            time += $"\n{meridem}";
        }

        return time;
    }

    public string CurrentTime
    {
        get
        {
            return time;
        }
    }
}

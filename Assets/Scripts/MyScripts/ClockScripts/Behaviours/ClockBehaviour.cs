using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBehaviour : C_Behaviour
{
    private bool is24HourNotation = false;

    public override void Init()
    {
        is24HourNotation = Condition;
        c_Time = new C_Time();
    }

    public override string DoBehaviour()
    {
        string time = c_Time.GetSystemTime(is24HourNotation);

        return time;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Truncate
{
    public static float TruncateNumber(this float value, int digits)
    {
        //multiplication value
        double mult = Math.Pow(10.0, digits);

        //Truncates the value and returns the result.
        double result = Math.Truncate(mult * value) / mult;
        return (float)result;
    }
}

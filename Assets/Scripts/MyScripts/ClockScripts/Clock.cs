using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Clock : MonoBehaviour
{
    enum TimeUnits
    {
        Milliseconds = 1,
        Seconds = 10,
        Minutes = 100,
        Hours = 1000
    }

    private float divisionNumber = 1000;

    private System.TimeSpan c_Time;

    private List<C_Behaviour> behaviours = new List<C_Behaviour>();

    public bool isTimer = false;

    public bool isStopwatch = false;

    public bool is24HourNotation = false;

    public bool isUseMilliseconds = true;

    private float milliseconds = 0;

    private float seconds = 0;

    private float minutes = 0;

    private float hours = 0;




    private void Start()
    {
        Debug.Log((int)TimeUnits.Milliseconds / divisionNumber);

        Debug.Log((int)TimeUnits.Seconds / divisionNumber);

        Debug.Log((int)TimeUnits.Minutes / divisionNumber);

        Debug.Log((int)TimeUnits.Hours / divisionNumber);


       
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetTime());




        //TODO
        //Check bool states here - add/remove behaviours as necessary
    }


    public string GetTime()
    {
        c_Time = System.DateTime.Now.TimeOfDay;

        milliseconds = (float)c_Time.Milliseconds;

        seconds = (float)c_Time.Seconds;

        minutes = (float)c_Time.Minutes;

        hours = (float)c_Time.Hours;


        if (is24HourNotation != true)
        {
            if (hours > 12)
            {
                hours -= 12;
            }
        }

        string time = $"{hours} : {minutes}.{seconds}{milliseconds}";

        return time;
    }

    public void AddBehaviour(C_Behaviour behaviour)
    {
        if (behaviour != null)
        {
            behaviours.Add(behaviour);
        }
    }

    public void RemoveBehaviour(C_Behaviour behaviour)
    {
        if (behaviour != null)
        {
            if (behaviours.Count > 0)
            {
                foreach (C_Behaviour b in behaviours)
                {
                    if (b != null)
                    {
                        if (b.Equals(behaviour))
                        {
                            behaviours.Remove(b);
                        }
                    }
                }
            }
        }
    }

}

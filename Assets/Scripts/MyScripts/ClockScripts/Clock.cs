using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;


public class Clock : MonoBehaviour
{

    private C_Behaviour activeBehaviour;

    private List<C_Behaviour> behaviours = new List<C_Behaviour>();

    private TextMeshProUGUI text;

    //-------------

    public bool isTimer = false;

    public bool isStopwatch = false;

    public bool is24HourNotation = false;

    [Space]

    public GameObject textObj;

    [Space]

    public UnityEvent<string> clockTime;

    private ClockBehaviour c;

    private TimerBehaviour t;

    private StopwatchBehaviour s;


    private void OnEnable()
    {
        if (textObj != null)
        {
            text = textObj.GetComponent<TextMeshProUGUI>();
        }

        c = new ClockBehaviour();

        s = new StopwatchBehaviour();

        //t = new TimerBehaviour();

        AddBehaviour(c);

        AddBehaviour(s);

        //AddBehaviour(t);


    }

    // Update is called once per frame
    void Update()
    {
        if (isTimer != true)
        {
            if (isStopwatch != true)
            {
                c.Condition = is24HourNotation;

                SetActiveBehaviour(c);

            }
            else
            {

                SetActiveBehaviour(s);
                
            }
        }
        else
        {
            //SetActiveBehaviour(t);
        }

        if (activeBehaviour != null)
        {
            if (text != null)
            {
                C_Time time = activeBehaviour.C_Update();

                text.text = time.CurrentTime;
            }
        }
        //TODO
        //Check bool states here - add/remove behaviours as necessary
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

    public void SetActiveBehaviour(C_Behaviour b)
    {
        if (b != null)
        {
            if (behaviours.Count > 0)
            {
                foreach (C_Behaviour cB in behaviours)
                {
                    if (b.Equals(cB))
                    {
                        activeBehaviour = cB;
                    }
                }
            }
        }
    }

    public void RemoveAllBehaviours()
    {
        if (behaviours.Count > 0)
        {
            behaviours.Clear();
        }
    }

    public void Toggle24HourNotation()
    {
        if (is24HourNotation == true)
        {
            is24HourNotation = false;
        }
        else
        {
            is24HourNotation = true;
        }
    }

    public void ToggleTimer()
    {
        if (isTimer == true)
        {
            isTimer = false;
        }
        else
        {
            isTimer = true;
        }
    }

    public void ToggleStopwatch()
    {
        if (isStopwatch == true)
        {
            isStopwatch = false;
        }
        else
        {
            isStopwatch = true;
        }
    }

    private Stopwatch FindStopwatch()
    {
        if (activeBehaviour != null)
        {
            if (activeBehaviour.Equals(s))
            {
                if (s != null)
                {
                    return s.Stopwatch;
                }

                return null;

            }
        }
        return null;
    }

    public void ResetStopwatch()
    {
        Stopwatch s = FindStopwatch();

        if (s != null)
        s.ResetStopwatch();

    }

    public void PauseStopwatch()
    {
        Stopwatch s = FindStopwatch();

        if (s != null)
        s.ToggleStopwatch(false);
    }

    public void ResumeStopwatch()
    {
        Stopwatch s = FindStopwatch();

        if (s != null)
        s.ToggleStopwatch(true);
    }

}

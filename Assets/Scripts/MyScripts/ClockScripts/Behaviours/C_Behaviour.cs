using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class C_Behaviour
{
    protected C_Time c_Time;

    protected bool doInit = true;

    public bool Condition;
    public virtual void Init()
    {
        // Setup base behaviour conditions here
    }

    public virtual C_Time C_Update()
    {
        //Executes Init behaviour once
        if (doInit == true)
        {
            Init();
            doInit = false;
        }
        DoBehaviour();

        return c_Time;
    }

    public virtual string DoBehaviour()
    {
        // Base Behaviour implementation
        return "";
    }
}


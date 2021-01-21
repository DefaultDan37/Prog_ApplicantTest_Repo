using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public GameObject ClockPrefab;

    [SerializeField]
    private List<Clock> clocks;

    private int clockLimit = 3;

    private int clockAmount = 0;

    private void Start()
    {
        InstantiateClock();
    }

    public void InstantiateClock()
    {
        if (clockAmount < clockLimit)
        {
            if (ClockPrefab != null)
            {
                GameObject clockObj = Instantiate(ClockPrefab, this.transform);

                Clock clock = clockObj.GetComponent<Clock>();

                if (clock != null)
                {
                    clocks.Add(clock);
                    clockAmount++;
                }
            }
        }


    }

    // Removes the last clock that was added to the list
    public void RemoveClock()
    {
        if (!(clockAmount <= 1))
        {
            if (clocks != null)
            {
                int c_index = clocks.Count - 1;

                Clock c = clocks[c_index];

                Destroy(c.gameObject);

                clockAmount--;

                clocks.RemoveAt(c_index);
            }
        }
    }
}

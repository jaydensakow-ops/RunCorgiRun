using System.Collections;
using UnityEngine;

public class BeerPlacer : TimedObjectPlacer
{
    public void Start()
    {
        minimumSecondsToWait = GameParameters.BeerMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.BeerMaximumSecondsToWait;
    }
}

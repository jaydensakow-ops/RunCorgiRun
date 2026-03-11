using UnityEngine;

public class PillPlacer : TimedObjectPlacer
{
    public void Start()
    {
        minimumSecondsToWait = GameParameters.PillMinimumSecondsToWait;
        maximumSecondsToWait = GameParameters.PillMaximumSecondsToWait;
    }
}

using UnityEngine;

public class Pill : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.PillSecondsOnScreen;
        base.Start();
    }
}

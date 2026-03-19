using UnityEngine;

public class Moonshine : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.MoonshineSecondsOnScreen;
        base.Start();
    }
}

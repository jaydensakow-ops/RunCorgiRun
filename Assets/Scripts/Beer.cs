using System.Collections;
using UnityEngine;

public class Beer : TimedObject
{
    public void Start()
    {
        secondsOnScreen = GameParameters.BeerSecondsOnScreen;
        base.Start();
    }
}

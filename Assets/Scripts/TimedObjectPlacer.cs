using System.Collections;
using UnityEngine;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject Prefab;
    
    public float minimumSecondsToWait;
    public float maximumSecondsToWait;
    
    private bool isOkToCreateBeer = true;
    void Update()
    {
        if (isOkToCreateBeer)
        {
            StartCoroutine(CountdownUntilCreation());
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isOkToCreateBeer = false;
        
        float secondsToWait = Random.Range(minimumSecondsToWait, 
            maximumSecondsToWait);
        
        yield return new WaitForSeconds(secondsToWait);
        Place();
        
        isOkToCreateBeer = true;
    }

    public virtual void Place()
    {
        Instantiate(Prefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
    
}

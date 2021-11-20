using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    public bool isFlickering = false;
    public float timeDelay;
    
    void Update()
    {
        if (isFlickering == false)
        {
            StartCoroutine(FlickeringLight());
        }
    }

    IEnumerable FlickeringLight()
    {
        isFlickering = true;
        this.gameObject.GetComponent<Light>().enable = false;
        timeDelay = Random.Range(0.01f, 0.02f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enable = true;
        timeDelay = Random.Range(0.01f, 0.02f);
        yield return new WaitForSeconds(timeDelay);
        isFlickering = false;
    }
}

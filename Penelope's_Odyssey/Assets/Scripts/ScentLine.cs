using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScentLine : MonoBehaviour
{
    public LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DrawSineWave(Vector3 startPoint, float amplitude, float wavelength)
    {
        float x = 0f;
        float y;
        float k = 2 * Mathf.PI / wavelength;
        line.positionCount = 200;
        for (int i = 0; i < line.positionCount; i++)
        {
            x += i * 0.001f;
            y = amplitude * Mathf.Sin(k * x);
            line.SetPosition(i, new Vector3(x, y, 0) + startPoint);
        }
    }
}

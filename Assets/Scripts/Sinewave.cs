using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sinewave : MonoBehaviour
{
    public LineRenderer myLineRenderer;
    public int points;
    public float amplitude = 1;
    public float frequency = 1;
    public float movementSpeed = 1;
    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    void Draw()
    {
        float xStart = 0f;
        float Tau = 2f * Mathf.PI;
        float xFinish = Tau;

        myLineRenderer.positionCount = points;
        for (int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin((Tau * frequency * x) + (Time.timeSinceLevelLoad * movementSpeed));
            myLineRenderer.SetPosition(currentPoint, new Vector3(x, y, 0));
        }
    }

    void Update()
    {
        Draw();
    }
}


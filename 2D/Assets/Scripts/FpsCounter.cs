using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    public TextMeshProUGUI fpsText;

    private float pollingTime = 0.5f;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.deltaTime;
        frameCount++;

        if(time >= pollingTime) {
            float frameRate = frameCount / time;
            frameRate = Mathf.Round(frameRate * 100) / 100;
            fpsText.text = frameRate.ToString() + " Fps";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}

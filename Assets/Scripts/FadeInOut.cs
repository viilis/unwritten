using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup startOfScene;
    public CanvasGroup endOfScene;
    private bool fadein = false;
    private bool fadeout = false;
    public float TimeToFade;

    // Update is called once per frame
    void Update()
    {
        if (fadein)
            if (endOfScene.alpha < 1)
            {
                endOfScene.alpha += TimeToFade * Time.deltaTime;
                if (endOfScene.alpha >= 1)
                {
                    fadein = false;
                }
            }

        if (fadeout)
            if (startOfScene.alpha >= 0)
            {
                startOfScene.alpha -= TimeToFade * Time.deltaTime;
                if (startOfScene.alpha == 0)
                {
                    fadeout = false;
                }
            }
    }

    public void FadeIn()
    {
        fadein = true;
    }

    public void FadeOut()
    {
        fadeout = true;
    }
}

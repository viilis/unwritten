using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public CanvasGroup _canvasgroup;
    private bool fadein = false;
    private bool fadeout = false;
    public float TimeToFade;

    // Update is called once per frame
    void Update()
    {
        if (fadein)
            if (_canvasgroup.alpha < 1)
            {
                _canvasgroup.alpha += TimeToFade * Time.deltaTime;
                if (_canvasgroup.alpha >= 1)
                {
                    fadein = false;
                }
            }

        if (fadeout)
            if (_canvasgroup.alpha >= 0)
            {
                _canvasgroup.alpha -= TimeToFade * Time.deltaTime;
                if (_canvasgroup.alpha == 0)
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

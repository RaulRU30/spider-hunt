using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public CanvasGroup uiCanvasGroup;
    public bool fadeIn = false;
    public bool fadeOut = false;

    public float timeToFade;
    private float _fadeSpeed;
    private bool _isUiCanvasGroupNotNull;

    void Start()
    {
        _isUiCanvasGroupNotNull = uiCanvasGroup != null;
        if (_isUiCanvasGroupNotNull)
        {
            uiCanvasGroup.alpha = 0;
        }
        _fadeSpeed = 1f / timeToFade;
    }

    void Update()
    {
        if (fadeIn)
        {
            if (canvasGroup.alpha < 1)
            {
                canvasGroup.alpha += _fadeSpeed  * Time.deltaTime;
                if(canvasGroup.alpha >= 1)
                {
                    fadeIn = false;
                }
            }
        }

        if (fadeOut)
        {
            if (canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= _fadeSpeed  * Time.deltaTime;
                if(canvasGroup.alpha == 0)
                {
                    fadeOut = false;
                }
            }
            if (_isUiCanvasGroupNotNull && uiCanvasGroup.alpha < 1)
            {
                uiCanvasGroup.alpha += _fadeSpeed  * Time.deltaTime;
            }
        }
    }
    
    public void FadeIn()
    {
        fadeIn = true;
    }
    
    public void FadeOut()
    {
        fadeOut = true;
    }
}

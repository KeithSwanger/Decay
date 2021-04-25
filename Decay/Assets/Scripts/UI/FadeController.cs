using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeController : MonoBehaviour
{
    public UnityAction FadeOutComplete;
    public UnityAction FadeInComplete;

    public Image fade;
    float startingAlpha = 0f;

    float fadeTimer = 0f;
    float fadeTime = 1f;

    public bool IsFading { get; private set; } = false;

    private bool _fadeIn = false;
    public bool FadeIn
    {
        get
        {
            return _fadeIn;
        }
        private set
        {
            _fadeIn = value;

            if (value)
            {
                _fadeOut = false;
            }
        }
    }

    private bool _fadeOut = false;
    public bool FadeOut
    {
        get
        {
            return _fadeOut;
        }
        private set
        {
            _fadeOut = value;

            if (value)
            {
                _fadeIn = false;
            }
        }
    }


    void Update()
    {
        if (IsFading)
        {
            float progress = fadeTimer / fadeTime;
            if (progress >= 1f)
            {
                progress = 1f;
            }

            if (FadeIn)
            {
                SetAlpha(startingAlpha - (progress * progress * startingAlpha));

                if(progress == 1f)
                {
                    OnFadeInComplete();
                }

            }
            else if (FadeOut)
            {
                SetAlpha(startingAlpha + (progress * progress * (1 - startingAlpha)));

                if(progress == 1f)
                {
                    OnFadeOutComplete();
                }
            }

            fadeTimer += Time.deltaTime;
        }
    }

    public void Stop()
    {
        FadeIn = false;
        FadeOut = false;
        IsFading = false;
    }


    public void SetAlpha(float alpha)
    {
        if (alpha < 0f)
        {
            alpha = 0f;
        }
        else if (alpha > 1f)
        {
            alpha = 1f;
        }

        fade.color = new Color(fade.color.r, fade.color.g, fade.color.b, alpha);
    }


    public void StartFadeIn(float timeToFade)
    {
        startingAlpha = fade.color.a;
        fadeTime = timeToFade;
        fadeTimer = 0f;
        FadeIn = true;
        IsFading = true;
    }


    public void StartFadeOut(float timeToFade)
    {
        startingAlpha = fade.color.a;
        fadeTime = timeToFade;
        fadeTimer = 0f;
        FadeOut = true;
        IsFading = true;
    }

    void OnFadeInComplete()
    {
        IsFading = false;
        FadeIn = false;

        FadeInComplete?.Invoke();
    }

    void OnFadeOutComplete()
    {
        IsFading = false;
        FadeOut = false;

        FadeOutComplete?.Invoke();
    }

}

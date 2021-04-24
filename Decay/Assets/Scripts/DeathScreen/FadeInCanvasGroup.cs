using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInCanvasGroup : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public TextRevealerManager textRevealerManager;

    bool canFadeIn = false;

    float fadeInCounter = 0f;
    float fadeProgress = 0f;
    public float fadeInTime = 1f;
    public float targetAlpha = 1f;

    float currentAlpha;
    void Awake()
    {
        if(fadeInTime == 0f)
        {
            Debug.LogError("fadeInTime CANNOT BE 0f, changing to 0.05f");
            fadeInTime = 0.05f;
        }

        currentAlpha = 0f;
        textRevealerManager.Finished += OnTextRevealerManagerFinished;
        canvasGroup.alpha = 0f;
    }


    void Update()
    {
        if (!canFadeIn)
        {
            return;
        }

        if(fadeInCounter / fadeInTime >= 1f)
        {
            fadeProgress = 1f;
        }
        else
        {
            fadeProgress = fadeInCounter / fadeInTime;
        }

        fadeInCounter += Time.deltaTime;

        currentAlpha = fadeProgress * fadeProgress * targetAlpha;

        canvasGroup.alpha = currentAlpha;
    }

    void OnTextRevealerManagerFinished()
    {
        canFadeIn = true;
    }
}

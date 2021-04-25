using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class FadeOutAndLoadScene : MonoBehaviour
{
    public string SceneToLoad;
    public Image fadeOutImage;


    public Questionaire questionaire;
    bool isFading = false;

    float fadeOutTimer;
    public float fadeOutTime = 2f;
    // Start is called before the first frame update
    void Awake()
    {
        fadeOutImage.color = new Color(fadeOutImage.color.r, fadeOutImage.color.g, fadeOutImage.color.b, 0f);
        if (questionaire != null)
        {
            questionaire.QuestionaireCompleted += OnQuestionaireComplete;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (isFading)
        {
            float newAlpha;
            if (fadeOutTimer / fadeOutTime > 1f)
            {
                newAlpha = 1f;
            }
            else
            {
                newAlpha = fadeOutTimer / fadeOutTime;
            }

            fadeOutImage.color = new Color(fadeOutImage.color.r, fadeOutImage.color.g, fadeOutImage.color.b, newAlpha);

            if (fadeOutImage.color.a >= 1f)
            {
                OnFadeComplete();
            }

            fadeOutTimer += Time.deltaTime;
        }
    }

    public void StartFading()
    {
        isFading = true;
    }


    private void OnQuestionaireComplete()
    {
        StartFading();
    }

    void OnFadeComplete()
    {
        isFading = false;
        SceneManager.LoadScene(SceneToLoad);
    }
}

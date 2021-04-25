using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextRevealer : MonoBehaviour
{
    public TMP_Text text;
    int charPosition = 0;

    public bool IsFinished { get; private set; } = false;
    private bool IsAllTextVisible = false;
    bool revealText = false;

    float characterRevealCounter;
    public float characterRevealDelay = 0.1f;

    float pauseBeforeFinishCounter;
    public float pauseBeforeFinishDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        text.maxVisibleCharacters = 0;
        characterRevealCounter = characterRevealDelay;
        pauseBeforeFinishCounter = pauseBeforeFinishDelay;
    }


    public void Execute()
    {
        if (!revealText || IsFinished)
        {
            // Early return, do nothing!
            return;
        }

        if (characterRevealCounter <= 0f)
        {
            characterRevealCounter = characterRevealDelay;
            
            text.maxVisibleCharacters++;

            if (text.maxVisibleCharacters >= text.textInfo.characterCount)
            {
                IsAllTextVisible = true;
            }
        }

        characterRevealCounter -= Time.deltaTime;


        if (IsAllTextVisible)
        {
            if(pauseBeforeFinishCounter <= 0)
            {
                IsFinished = true;
            }

            pauseBeforeFinishCounter -= Time.deltaTime;
        }
    }


    public void RevealText()
    {
        revealText = true;
    }


}

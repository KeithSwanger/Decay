using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HouseVisitController : MonoBehaviour
{
    public TextRevealer topTextRevealer;
    public TextRevealer middleTextRevealer;
    public TextRevealer bottomTextRevealer;

    bool fadeOutTextRevealers = false;

    PlayerStat topTextStatToModify;
    PlayerStat bottomTextStatToModify;

    TextRevealer currentTextRevealer;

    GameController gameController;



    bool isVisiting = false;
    bool isFadingOut = false;

    private void Awake()
    {
        gameController = GameController.Instance;
        topTextRevealer.TextRevealFinished += OnTopTextFinished;
        middleTextRevealer.TextRevealFinished += OnMiddleTextFinished;
        bottomTextRevealer.TextRevealFinished += OnBottomTextFinished;
    }


    public void OnTopTextFinished()
    {
        currentTextRevealer = middleTextRevealer;
        middleTextRevealer.RevealText();

        int statModifier = Random.Range(1, 3);

        if (gameController.player.Stats.GetStatVal(topTextStatToModify) - statModifier >= 0)
        {
            gameController.player.Stats.AddToStat(topTextStatToModify, -1 * statModifier);
        }
    }

    private void OnMiddleTextFinished()
    {
        currentTextRevealer = bottomTextRevealer;
        bottomTextRevealer.RevealText();
    }

    private void OnBottomTextFinished()
    {
        int statModifier = Random.Range(1, 4);

        if (gameController.player.Stats.GetStatVal(bottomTextStatToModify) + statModifier <= 9)
        {
            gameController.player.Stats.AddToStat(bottomTextStatToModify, statModifier);
        }
        else
        {
            gameController.player.Stats.SetStat(bottomTextStatToModify, 9); // In case the random value would would add 8 + 2 = 10, make sure we're not throwing away the valid modifier
        }

        OnHouseVisitComplete();
    }

    private void OnHouseVisitComplete()
    {
        fadeOutTextRevealers = true;
        gameController.fadeController.StartFadeIn(1f);

        gameController.player.ChangeState(new PlayerState_Idle(gameController.player));
    }

    

    

    private void Update()
    {
        if (isVisiting && !isFadingOut)
        {
            if (!currentTextRevealer.IsFinished)
            {
                currentTextRevealer.Execute();
            }
        }

        if (fadeOutTextRevealers)
        {
            float newAlpha = topTextRevealer.text.alpha - Time.deltaTime;

            if(newAlpha <= 0f)
            {
                fadeOutTextRevealers = false;
            }

            topTextRevealer.text.alpha = newAlpha;
            middleTextRevealer.text.alpha = newAlpha;
            bottomTextRevealer.text.alpha = newAlpha;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            OnPlayerEntered();
        }
    }

    private void OnPlayerEntered()
    {
        Day day = gameController.dayManager.currentDay;

        if(day.placesVisited.Count < 2)
        {
            // Not done for the day
            return;
        }

        gameController.dayManager.StartNewDay();

        StartVisit();
    }

    void StartVisit()
    {
        gameController.player.Stats.AddToStat(PlayerStat.Decay, 1);

        if(gameController.player.Stats.Decay >= 10)
        {
            gameController.player.ChangeState(new PlayerState_Visiting(gameController.player));
            return; // Game over, don't start revealing text because it will not look nice
        }

        topTextRevealer.ResetRevealer();
        middleTextRevealer.ResetRevealer();
        bottomTextRevealer.ResetRevealer();

        topTextRevealer.text.alpha = 1f;
        middleTextRevealer.text.alpha = 1f;
        bottomTextRevealer.text.alpha = 1f;

        currentTextRevealer = topTextRevealer;
        gameController.fadeController.StartFadeOut(1f);
        gameController.fadeController.FadeOutComplete += OnFadeOutComplete;
        isVisiting = true;
        isFadingOut = true;

        gameController.player.ChangeState(new PlayerState_Visiting(gameController.player));
    }

    private void OnFadeOutComplete()
    {
        gameController.fadeController.FadeOutComplete -= OnFadeOutComplete;
        GenerateMessages();

        topTextRevealer.RevealText();
        currentTextRevealer = topTextRevealer;

        isFadingOut = false;
    }



    private void GenerateMessages()
    {
        float randomStatTop = Random.value * 4f;

        if(randomStatTop <= 1)
        {
            topTextRevealer.text.text = "I found a bit of money";
            topTextStatToModify = PlayerStat.Debt;
        }
        else if (randomStatTop <= 2)
        {
            topTextRevealer.text.text = "I'm feeling happy";
            topTextStatToModify = PlayerStat.Depression;
        }
        else if (randomStatTop <= 3)
        {
            topTextRevealer.text.text = "I feel a bit healthier";
            topTextStatToModify = PlayerStat.Disease;
        }
        else if (randomStatTop <= 4)
        {
            topTextRevealer.text.text = "Work has been pretty relaxed";
            topTextStatToModify = PlayerStat.Distress;
        }


        float randomStatBottom = Random.value * 4f;

        if (randomStatBottom <= 1)
        {
            bottomTextRevealer.text.text = "Money just slips through my hands";
            bottomTextStatToModify = PlayerStat.Debt;
        }
        else if (randomStatBottom <= 2)
        {
            bottomTextRevealer.text.text = "I can't stop having the worst thoughts";
            bottomTextStatToModify = PlayerStat.Depression;
        }
        else if (randomStatBottom <= 3)
        {
            bottomTextRevealer.text.text = "My body does not feel right";
            bottomTextStatToModify = PlayerStat.Disease;
        }
        else if (randomStatBottom <= 4)
        {
            bottomTextRevealer.text.text = "There's still so much work to do";
            bottomTextStatToModify = PlayerStat.Distress;
        }
    }


}

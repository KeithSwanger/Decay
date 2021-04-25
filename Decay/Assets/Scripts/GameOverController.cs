using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    GameController gameController;
    private PlayerStat gameEndingStat;
    public bool isGameOver = false;

    public string sceneNameDeathDebt;
    public string sceneNameDeathDepression;
    public string sceneNameDeathDisease;
    public string sceneNameDeathDistress;
    public string sceneNameDeathDecay;

    float loadSceneTimer = 0f;
    float loadSceneTime = 2.5f;

    private void Awake()
    {
        gameController = GameController.Instance;
        gameController.player.Stats.StatChanged += OnPlayerStatChanged;
    }

    private void OnPlayerStatChanged(PlayerStat stat, int oldValue, int newValue)
    {
        if (isGameOver)
        {
            // Don't update, the game is already ending, could lead to wrong ending
            return;
        }
        
        if (newValue >= 10)
        {
            gameController.globalFadeController.StartFadeOut(2f);
            gameController.globalFadeController.FadeOutComplete += OnFadeOutComplete;

            gameEndingStat = stat;
            isGameOver = true;
            
            
        }
    }

    private void OnFadeOutComplete()
    {
        switch (gameEndingStat)
        {
            case (PlayerStat.Debt):
                {
                    SceneManager.LoadScene(sceneNameDeathDebt);
                    break;
                }
            case (PlayerStat.Depression):
                {
                    SceneManager.LoadScene(sceneNameDeathDepression);
                    break;
                }
            case (PlayerStat.Disease):
                {
                    SceneManager.LoadScene(sceneNameDeathDisease);
                    break;
                }
            case (PlayerStat.Distress):
                {
                    SceneManager.LoadScene(sceneNameDeathDistress);
                    break;
                }
            case (PlayerStat.Decay):
                {
                    SceneManager.LoadScene(sceneNameDeathDecay);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}

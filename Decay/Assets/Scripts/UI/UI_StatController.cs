using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatController : MonoBehaviour
{
    GameController gameController;


    public StatBar statbarDebt;
    public StatBar statbarDepression;
    public StatBar statbarDisease;
    public StatBar statbarDistress;
    public StatBar statbarDecay;

    void Awake()
    {
        gameController = GameController.Instance;
        gameController.player.Stats.StatChanged += OnStatChanged;
    }

    private void OnStatChanged(PlayerStat stat, int oldVal, int newVal)
    {

        int newSpriteIndex = Mathf.Min(Mathf.Max(newVal, 0), 10);

        switch (stat)
        {
            case (PlayerStat.Debt):
                {
                    statbarDebt.SetSprite(newSpriteIndex);
                    break;
                }
            case (PlayerStat.Depression):
                {
                    statbarDepression.SetSprite(newSpriteIndex);
                    break;
                }
            case (PlayerStat.Disease):
                {
                    statbarDisease.SetSprite(newSpriteIndex);
                    break;
                }
            case (PlayerStat.Distress):
                {
                    statbarDistress.SetSprite(newSpriteIndex);
                    break;
                }
            case (PlayerStat.Decay):
                {
                    statbarDecay.SetSprite(newSpriteIndex);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

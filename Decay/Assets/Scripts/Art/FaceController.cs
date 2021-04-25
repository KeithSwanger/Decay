using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class FaceController : MonoBehaviour
{
    public SpriteRenderer faceRenderer;

    public Sprite faceDebt;
    public Sprite faceDepression;
    public Sprite faceDisease;
    public Sprite faceDistress;
    public Sprite faceDecay;

    GameController gameController;

    private void Awake()
    {
        gameController = GameController.Instance;
        gameController.player.Stats.StatChanged += OnPlayerStatChanged;
    }

    private void Start()
    {
        OnPlayerStatChanged(PlayerStat.Debt, 0, 0); // Just to get the right face on start
    }

    private void OnPlayerStatChanged(PlayerStat stat, int oldValue, int newValue)
    {
        PlayerStat highestStat = gameController.player.Stats.GetHighestStat();

        switch (highestStat)
        {
            case (PlayerStat.Debt):
                {
                    faceRenderer.sprite = faceDebt;
                    break;
                }
            case (PlayerStat.Depression):
                {
                    faceRenderer.sprite = faceDepression;
                    break;
                }
            case (PlayerStat.Disease):
                {
                    faceRenderer.sprite = faceDisease;
                    break;
                }
            case (PlayerStat.Distress):
                {
                    faceRenderer.sprite = faceDistress;
                    break;
                }
            case (PlayerStat.Decay):
                {
                    faceRenderer.sprite = faceDecay;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

}

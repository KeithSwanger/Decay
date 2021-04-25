using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingType
{
    House,
    LiquorStore,
    Work,
    Work2,
    Hospital,
    Gym
}

public class BuildingVisitController : MonoBehaviour
{
    public BuildingType buildingType;

    public int modifyDebt = 0;
    public int modifyDepression = 0;
    public int modifyDisease = 0;
    public int modifyDistress = 0;
    public int modifyDecay = 0;

    GameController gameController;

    bool isFadingOut = false;
    bool isVisiting = false;

    float visitTimer = 0f;
    public float visitTime = 0.5f;

    private void Awake()
    {
        gameController = GameController.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(isVisiting && !isFadingOut)
        {
            if(visitTimer <= 0f)
            {
                OnVisitComplete();
            }

            visitTimer -= Time.deltaTime;
        }

    }

    private void OnVisitComplete()
    {
        isVisiting = false;
        gameController.fadeController.StartFadeIn(1f);
        gameController.player.ChangeState(new PlayerState_Idle(gameController.player));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            OnPlayerEntered();
        }
    }

    private void OnPlayerEntered()
    {
        Day day = gameController.dayManager.currentDay;
        if (day.placesVisited.Contains(buildingType) || day.placesVisited.Count >= day.maxPlacesToVisit)
        {
            // Place already visited, no need to do anything
            return;
        }

        day.placesVisited.Add(this.buildingType);

        StartVisit();
    }

    private void StartVisit()
    {
        gameController.fadeController.StartFadeOut(1f);
        gameController.fadeController.FadeOutComplete += OnFadeOutComplete;
        isVisiting = true;
        isFadingOut = true;
        visitTimer = visitTime;

        gameController.player.ChangeState(new PlayerState_Visiting(gameController.player));
    }

    private void OnFadeOutComplete()
    {
        gameController.fadeController.FadeOutComplete -= OnFadeOutComplete; // Remove this listener for this visit
        isFadingOut = false;

        ModifyStats();
    }

    private void ModifyStats()
    {
        PlayerController player = gameController.player;

        player.Stats.AddToStat(PlayerStat.Debt,       modifyDebt);
        player.Stats.AddToStat(PlayerStat.Depression, modifyDepression);
        player.Stats.AddToStat(PlayerStat.Disease,    modifyDisease);
        player.Stats.AddToStat(PlayerStat.Distress,   modifyDistress);
        player.Stats.AddToStat(PlayerStat.Decay,      modifyDecay);
    }
}

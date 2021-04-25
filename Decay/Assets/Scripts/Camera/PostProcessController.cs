using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessController : MonoBehaviour
{
    public Camera postProcessCamera;
    public PostProcessVolume postProcess;
    ColorGrading colorGrading;
    Vignette vignette;
    Grain grain;
    GameController gameController;

    float currentDepression = 0f;
    float targetDepression = 0f;

    float currentDistress = 0f;
    float targetDistress = 0f;


    void Awake()
    {
        gameController = GameController.Instance;
        colorGrading = (ColorGrading)postProcess.profile.settings.Find(x => x.GetType() == typeof(ColorGrading));
        vignette = (Vignette)postProcess.profile.settings.Find(x => x.GetType() == typeof(Vignette));
        grain = (Grain)postProcess.profile.settings.Find(x => x.GetType() == typeof(Grain));

        gameController.player.Stats.StatChanged += OnPlayerStatChanged;
    }



    private void Start()
    {
        OnPlayerStatChanged(PlayerStat.Depression, 0, gameController.player.Stats.Depression);
        OnPlayerStatChanged(PlayerStat.Distress, 0, gameController.player.Stats.Distress);
    }

    private void OnPlayerStatChanged(PlayerStat stat, int oldValue, int newValue)
    {


        switch (stat)
        {
            case (PlayerStat.Depression):
                {
                    targetDepression = -100f * (((float)newValue + 1) / 10f); // fully desaturated at 8
                    targetDepression = Mathf.Clamp(targetDepression, -100f, 0f);
                    if (newValue <= 5f)
                    {
                        targetDepression += 5f; // earlier levels have a bit more saturation
                    }
                    break;
                }
            case (PlayerStat.Distress):
                {
                    targetDistress = (newValue) / 10f; // fully vignette at 8 
                    targetDistress = Mathf.Clamp(targetDistress, 0f, 1f);
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
        if (currentDepression != targetDepression)
        {
            currentDepression += Mathf.Sign(targetDepression - currentDepression) * 100f * Time.deltaTime / 10;

            if (Mathf.Abs(targetDepression - currentDepression) < 0.0001)
            {
                currentDepression = targetDepression;
            }

        }

        colorGrading.saturation.value = currentDepression;

        if (currentDistress != targetDistress)
        {
            currentDistress += Mathf.Sign(targetDistress - currentDistress) * Time.deltaTime / 10;

            if (Mathf.Abs(targetDistress - currentDistress) < 0.0001)
            {
                currentDistress = targetDistress;
            }

            Debug.Log($"Current Vignette: {vignette.intensity.value}");
        }

        vignette.intensity.value = Mathf.Clamp(0.2f + currentDistress * 0.8f, 0f, 1f);
        grain.intensity.value = Mathf.Clamp(currentDistress / 2f, 0f, 0.7f);

    }
}

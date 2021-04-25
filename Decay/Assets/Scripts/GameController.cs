using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            }

            return _instance;
        }
    }

    public PlayerController player;

    MainMenuInfo mainMenuInfo;
    public FadeController fadeController;
    public FadeController globalFadeController;

    public CameraController cameraController;

    void Awake()
    {
        mainMenuInfo = MainMenuInfo.Instance;

        if(fadeController == null)
        {
            fadeController = GetComponent<FadeController>();
        }

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        fadeController.SetAlpha(1f);
        fadeController.StartFadeIn(2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

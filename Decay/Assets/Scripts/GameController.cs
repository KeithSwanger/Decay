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

    public SoundManager soundManager { get; private set; }
    public AudioClip themeSong;

    public PlayerController player;

    MainMenuInfo mainMenuInfo;
    public FadeController fadeController;
    public FadeController globalFadeController;

    public CameraController cameraController;

    public DayManager dayManager;


    void Awake()
    {
        soundManager = SoundManager.Instance;
        mainMenuInfo = MainMenuInfo.Instance;

        if(fadeController == null)
        {
            fadeController = GetComponent<FadeController>();
        }

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        globalFadeController.SetAlpha(1f);
        globalFadeController.StartFadeIn(2f);
    }

    private void Start()
    {
        if (!soundManager.isPlayingMusic)
        {
            soundManager.PlayMusic(themeSong, 0.5f);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusicOnMainMenu : MonoBehaviour
{

    public AudioClip music;
    SoundManager soundManager;

    private void Awake()
    {
        soundManager = SoundManager.Instance;
    }

    private void Start()
    {
        if (!soundManager.isPlayingMusic)
        {
            soundManager.PlayMusic(music, 0.5f);
        }
    }
}

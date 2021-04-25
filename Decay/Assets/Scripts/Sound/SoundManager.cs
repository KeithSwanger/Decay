using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{

    private static SoundManager _instance = null;
    public static SoundManager instance
    {
        get
        {
            if (_instance == null)
            {
                // Create sound manager here
                GameObject i = new GameObject();
                _instance = i.AddComponent<SoundManager>();
                i.name = "Sound Manager";
            }

            return _instance;
        }
    }

    AudioSource musicSource;
    List<AudioSource> audioSources = new List<AudioSource>();

    public float soundVolume = 0.9f;
    private float _musicVolume = 0.45f;
    public float musicVolume
    {
        get
        {
            return _musicVolume;
        }
        set
        {
            if (musicSource != null)
            {
                musicSource.volume = value;
            }
        }
    }

    public bool isPlayingMusic = false;



    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);

        GameObject music = new GameObject("Music Source");
        music.transform.SetParent(gameObject.transform);
        musicSource = music.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;

        for (int i = 0; i < 20; i++)
        {
            GameObject sound = new GameObject("Sound Effect Source");
            sound.transform.SetParent(gameObject.transform);
            AudioSource source = sound.AddComponent<AudioSource>();
            source.loop = false;
            source.spatialBlend = 1f;
            source.playOnAwake = false;
            audioSources.Add(source);
        }
    }


    public void PlayMusic(AudioClip music, float volume)
    {
        musicSource.Stop();
        musicSource.volume = volume;
        musicSource.clip = music;

        musicSource.loop = true;
        musicSource.Play();

        isPlayingMusic = true;
    }

    public void PlaySoundEffect(AudioClip soundEffect, float volume, Vector2 position, float pitch = 1f, bool loop = false)
    {
        AudioSource source = null;

        for (int i = 0; i < audioSources.Count; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                source = audioSources[i];
                break;
            }
        }

        if (source != null)
        {
            source.pitch = pitch;
            source.loop = loop;
            source.clip = soundEffect;
            source.volume = volume;
            source.gameObject.transform.position = position;

            source.Play();
        }
    }

    public void ForcePlaySoundEffect(AudioClip soundEffect, float volume, Vector2 position, float pitch)
    {
        AudioSource source = null;

        for (int i = 0; i < audioSources.Count; i++)
        {
            if (!audioSources[i].isPlaying)
            {
                source = audioSources[i];
                break;
            }
        }

        if (source == null)
        {
            //AudioSource.PlayClipAtPoint(soundEffect, position, volume);
            source = audioSources[Random.Range(0, audioSources.Count)];
        }

        source.pitch = pitch;
        source.clip = soundEffect;
        source.volume = volume;
        source.gameObject.transform.position = position;

        source.Play();

    }
}

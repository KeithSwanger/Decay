using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public float frameRate = 12;
    public bool playOnStart = false;
    public bool onlyPlayOnce = false;

    private int currentFrame = 0;

    private bool animate = false;
    private bool animationHasPlayed = false;

    private float frameLength;

    private float frameTimer;


    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        frameLength = 1f / frameRate;
        if (playOnStart)
        {
            Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (onlyPlayOnce && animationHasPlayed)
        {
            // Do nothing because the last frame is showing
        }
        else if (animate)
        {
            UpdateAnimation();
        }
    }

    private void UpdateAnimation()
    {
        if (frameTimer <= 0f)
        {
            NextFrame();
            frameTimer = frameLength;
        }

        frameTimer -= Time.deltaTime;

        spriteRenderer.sprite = sprites[currentFrame];
    }

    private void NextFrame()
    {
        currentFrame++;

        if (currentFrame >= sprites.Length)
        {
            animationHasPlayed = true;

            if (onlyPlayOnce)
            {
                currentFrame = sprites.Length - 1;
            }
            else
            {
                currentFrame = 0;
            }

        }
    }


    public void Play()
    {
        animate = true;
    }

    public void PlayOnce()
    {
        animate = true;
        onlyPlayOnce = true;
    }


    public void Stop()
    {
        animate = false;

    }

    public void Reset()
    {
        Stop();
        spriteRenderer.sprite = sprites[0];
        currentFrame = 0;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        return spriteRenderer;
    }
}
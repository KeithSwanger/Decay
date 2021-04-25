using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiseaseSpawn : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public SpriteAnimator spawnAnimator;
    public SpriteAnimator loopAnimator;
    public SpriteAnimator dieAnimator;

    PlayerController player;

    private State currentState;

    bool isDangerous = false;

    float timeAliveCounter = 15f;

    private enum State
    {
        Spawning,
        Looping,
        Dying
    }

    private void Awake()
    {
        spriteRenderer.sprite = spawnAnimator.sprites[0];
        player = GameController.Instance.player;
    }

    private void Start()
    {
        timeAliveCounter += Random.Range(-1f, 1f);
        spawnAnimator.Play();
        currentState = State.Spawning;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case (State.Spawning):
                {
                    if (spawnAnimator.AnimationHasPlayed)
                    {
                        currentState = State.Looping;
                        spawnAnimator.Stop();
                        loopAnimator.Play();
                        isDangerous = true;
                    }
                    break;
                }
            case (State.Looping):
                {
                    isDangerous = true;

                    if(timeAliveCounter <= 0f)
                    {
                        currentState = State.Dying;
                        loopAnimator.Stop();
                        dieAnimator.PlayOnce();
                    }
                    timeAliveCounter -= Time.deltaTime;
                    break;
                }
            case (State.Dying):
                {
                    isDangerous = false;

                    if (dieAnimator.AnimationHasPlayed)
                    {
                        dieAnimator.Stop();
                        Destroy(this.gameObject);
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private void Die()
    {
        spawnAnimator.Stop();
        loopAnimator.Stop();
        currentState = State.Dying;
        dieAnimator.PlayOnce();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDangerous || player.IsInvincible)
        {
            return;
        }

        if(collision.GetComponent<PlayerHurtBox>() != null)
        {
            Die();
            player.Stats.AddToStat(PlayerStat.Disease, 1);
        }
    }
}

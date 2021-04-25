using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float moveSpeed = 10f;

    Vector2 targetLocation;

    public SpriteRenderer spriteRenderer;
    public SpriteAnimator spawnAnimator;
    public SpriteAnimator loopAnimator;
    public SpriteAnimator dieAnimator;

    PlayerController player;

    private State currentState;

    bool isDangerous = false;

    float timeAliveCounter = 5f;

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
        transform.position = new Vector2(player.transform.position.x, player.transform.position.y + 0.3f); // Account for player's pivot
    }

    private void Start()
    {
        timeAliveCounter += Random.Range(-1f, 1f);
        spawnAnimator.Play();
        currentState = State.Spawning;

        targetLocation.x = player.transform.position.x + Random.Range(-8f, 8f);
        targetLocation.y = player.transform.position.y + Random.Range(-8f, 8f);
    }


    private void Update()
    {
        switch (currentState)
        {
            case (State.Spawning):
                {
                    transform.position = Vector2.MoveTowards(transform.position, targetLocation, 10f * Time.deltaTime);

                    if (spawnAnimator.AnimationHasPlayed)
                    {
                        currentState = State.Looping;
                        spawnAnimator.Stop();
                        loopAnimator.Play();
                        isDangerous = true;
                        SetVelocityTowardPlayer();
                    }
                    break;
                }
            case (State.Looping):
                {
                    isDangerous = true;

                    if (timeAliveCounter <= 0f)
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

    public void SetVelocityTowardPlayer()
    {
        Vector2 moveVector = player.transform.position - transform.position;
        moveVector = moveVector.normalized;
        rigidBody.velocity = moveVector * moveSpeed;
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

        if (collision.GetComponent<PlayerHurtBox>() != null)
        {
            Die();
            rigidBody.velocity = Vector2.zero;
            player.Stats.AddToStat(PlayerStat.Depression, 1);
        }
    }

}

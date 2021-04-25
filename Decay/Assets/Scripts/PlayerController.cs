using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteAnimator))]

public class PlayerController : MonoBehaviour
{
    public PlayerStats Stats { get; private set; } = new PlayerStats();
    public IPlayerState PlayerState { get; private set; }
    public Rigidbody2D rb;

    public SpriteAnimator spriteAnimatorWalk;
    public SpriteAnimator spriteAnimatorIdle;

    public Transform playerBoundsLeft;
    public Transform playerBoundsRight;
    public Transform playerBoundsTop;
    public Transform playerBoundsBottom;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ChangeState(new PlayerState_Move(this));

        Stats.InitializePlayerStats();
        Stats.Debt = MainMenuInfo.Instance.debt;
        Stats.Depression = MainMenuInfo.Instance.depression;
        Stats.Disease = MainMenuInfo.Instance.disease;
        Stats.Distress = MainMenuInfo.Instance.distress;
    }

    void Update()
    {
        if (PlayerState != null)
        {
            PlayerState.Execute();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerStat stat = (PlayerStat)Random.Range(0, 5);

            Stats.AddToStat(stat, Random.Range(-3, 4));
        }

    }

    public void ChangeState(IPlayerState newState)
    {

        if (this.PlayerState != null)
        {
            PlayerState.Exit();
        }

        PlayerState = newState;

        if (newState != null)
        {
            PlayerState.Enter();
        }
    }

    public void StartWalkAnimation()
    {
        spriteAnimatorIdle.Stop();
        spriteAnimatorWalk.Play();
    }

    public void StartIdleAnimation()
    {
        spriteAnimatorWalk.Stop();
        spriteAnimatorIdle.Play();
    }

    private void LateUpdate()
    {
        Vector2 newPosition = transform.position;
        if (transform.position.x < playerBoundsLeft.position.x + 0.5f)
        {
            newPosition.x = playerBoundsLeft.position.x + 0.5f;
        }
        else if (transform.position.x > playerBoundsRight.position.x - 0.5f)
        {
            newPosition.x = playerBoundsRight.position.x - 0.5f;
        }

        if (transform.position.y < playerBoundsBottom.position.y + 0.5f)
        {
            newPosition.y = playerBoundsBottom.position.y + 0.5f;
        }
        else if (transform.position.y > playerBoundsTop.position.y - 2f)
        {
            newPosition.y = playerBoundsTop.position.y - 2f;
        }

        if(newPosition.x != transform.position.x || newPosition.y != transform.position.y)
        {
            transform.position = newPosition;
        }
    }
}

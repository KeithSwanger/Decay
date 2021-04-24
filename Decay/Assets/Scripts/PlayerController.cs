using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public PlayerStats Stats { get; private set; }
    public IPlayerState PlayerState { get; private set; }
    public Rigidbody2D rb;

    private void Start()
    {
        Stats = new PlayerStats();
        rb = GetComponent<Rigidbody2D>();
        ChangeState(new PlayerState_Move(this));
    }

    void Update()
    {
        if(PlayerState != null)
        {
            PlayerState.Execute();
        }
    }

    public void ChangeState(IPlayerState newState)
    {

        if(this.PlayerState != null)
        {
            PlayerState.Exit();
        }

        PlayerState = newState;

        if(newState != null)
        {
            PlayerState.Enter();
        }
    }
}

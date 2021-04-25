using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Visiting : IPlayerState
{
    public PlayerController player;
    Vector2 moveVec = Vector2.zero;


    public PlayerState_Visiting(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.rb.velocity = Vector2.zero;
        player.StartIdleAnimation();
    }

    public void Execute()
    {
        player.rb.velocity = Vector2.zero;
    }

    public void Exit()
    {
        // throw new System.NotImplementedException();
    }
}
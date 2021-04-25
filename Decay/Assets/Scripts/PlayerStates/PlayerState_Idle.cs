using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Idle : IPlayerState
{
    public PlayerController player;
    Vector2 moveVec = Vector2.zero;
    

    public PlayerState_Idle(PlayerController player)
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
        HandleInput();

        player.rb.velocity = Vector2.zero;

        if(moveVec != Vector2.zero)
        {
            player.ChangeState(new PlayerState_Move(player));
        }
    }

    void HandleInput()
    {
        moveVec = Vector2.zero;

        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");
    }

    public void Exit()
    {
       // throw new System.NotImplementedException();
    }
}

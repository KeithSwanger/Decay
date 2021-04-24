using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState_Move : IPlayerState
{
    public PlayerController player;
    Vector2 moveVec = Vector2.zero;
    

    public PlayerState_Move(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.rb.velocity = moveVec;
    }

    public void Execute()
    {
        HandleInput();

        player.rb.velocity = moveVec * player.Stats.MoveSpeed;
    }

    void HandleInput()
    {
        moveVec = Vector2.zero;

        moveVec.x = Input.GetAxisRaw("Horizontal");
        moveVec.y = Input.GetAxisRaw("Vertical");

        if (moveVec.sqrMagnitude > 1f)
        {
            moveVec = moveVec.normalized;
        }
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}

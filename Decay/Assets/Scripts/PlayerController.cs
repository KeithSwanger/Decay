using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public PlayerStats Stats { get; private set; } = new PlayerStats();
    public IPlayerState PlayerState { get; private set; }
    public Rigidbody2D rb;

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
        if(PlayerState != null)
        {
            PlayerState.Execute();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerStat stat = (PlayerStat)Random.Range(0, 5);

            Stats.AddToStat(stat, Random.Range(-1, 4));
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

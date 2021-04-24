using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    private float _debt = 0f;
    public float Debt
    {
        get
        {
            return _debt;
        }
        set
        {
            _debt = value;
        }
    }

    private float _distress = 0f;
    public float Distress
    {
        get
        {
            return _distress;
        }
        set
        {
            _distress = value;
        }
    }

    private float _depression = 0f;
    public float Depression
    {
        get
        {
            return _depression;
        }
        set
        {
            _depression = value;
        }
    }

    private float _disease = 0f;
    public float Disease
    {
        get
        {
            return _disease;
        }
        set
        {
            _disease = value;
        }
    }

    private float _decay = 0f;
    public float Decay
    {
        get
        {
            return _decay;
        }
        set
        {
            _decay = value;
        }
    }

    private float _moveSpeed = 1f;
    public float MoveSpeed
    {
        get
        {
            return _moveSpeed;
        }
        set
        {
            _moveSpeed = value;
        }
    }


    public PlayerStats()
    {
        InitializePlayerStats();
    }

    void InitializePlayerStats()
    {
        Debt       = 0f;
        Distress   = 0f;
        Depression = 0f;
        Disease    = 0f;
        Decay      = 0f;

        MoveSpeed = 7f;
    }



}

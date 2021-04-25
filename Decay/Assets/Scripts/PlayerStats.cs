using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum PlayerStat
{
    Debt,
    Depression,
    Disease,
    Distress,
    Decay
}
public class PlayerStats
{
    // Stat changed, old value, new value
    public UnityAction<PlayerStat, int, int> StatChanged;

    private int _debt = 0;
    public int Debt
    {
        get
        {
            return _debt;
        }
        set
        {
            int previous = _debt;
            _debt = value;
            StatChanged?.Invoke(PlayerStat.Debt, previous, value);
        }
    }

    private int _distress = 0;
    public int Distress
    {
        get
        {
            return _distress;
        }
        set
        {
            int previous = _distress;
            _distress = value;
            StatChanged?.Invoke(PlayerStat.Distress, previous, value);
        }
    }

    private int _depression = 0;
    public int Depression
    {
        get
        {
            return _depression;
        }
        set
        {
            int previous = _depression;
            _depression = value;
            StatChanged?.Invoke(PlayerStat.Depression, previous, value);
        }
    }

    private int _disease = 0;
    public int Disease
    {
        get
        {
            return _disease;
        }
        set
        {
            int previous = _disease;
            _disease = value;
            StatChanged?.Invoke(PlayerStat.Disease, previous, value);
        }
    }

    private int _decay = 0;
    public int Decay
    {
        get
        {
            return _decay;
        }
        set
        {
            int previous = _decay;
            _decay = value;
            StatChanged?.Invoke(PlayerStat.Decay, previous, value);
        }
    }

    private float _moveSpeed = 7f;
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

    public void InitializePlayerStats()
    {
        Debt = 0;
        Distress = 0;
        Depression = 0;
        Disease = 0;
        Decay = 1;

        MoveSpeed = 7f;
    }

    public void SetStat(PlayerStat stat, int value)
    {
        switch (stat)
        {
            case (PlayerStat.Debt):
                {
                    Debt = value;
                    break;
                }
            case (PlayerStat.Depression):
                {
                    Depression = value;
                    break;
                }
            case (PlayerStat.Disease):
                {
                    Disease = value;
                    break;
                }
            case (PlayerStat.Distress):
                {
                    Distress = value;
                    break;
                }
            case (PlayerStat.Decay):
                {
                    Decay = value;
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void AddToStat(PlayerStat stat, int value)
    {
        if(value == 0)
        {
            return;
        }

        switch (stat)
        {
            case (PlayerStat.Debt):
                {
                    Debt = GetClampedValue(Debt + value);
                    break;
                }
            case (PlayerStat.Depression):
                {
                    Depression = GetClampedValue(Depression + value);
                    break;
                }
            case (PlayerStat.Disease):
                {
                    Disease = GetClampedValue(Disease + value);
                    break;
                }
            case (PlayerStat.Distress):
                {
                    Distress = GetClampedValue(Distress + value);
                    break;
                }
            case (PlayerStat.Decay):
                {
                    Decay = GetClampedValue(Decay + value);
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    private int GetClampedValue(int value)
    {
        return Mathf.Min(Mathf.Max(value, 0), 10);
    }

    public PlayerStat GetHighestStat()
    {
        PlayerStat highestStat = PlayerStat.Decay;
        int highestStatValue = 0;

        if(Debt > highestStatValue)
        {
            highestStat = PlayerStat.Debt;
            highestStatValue = Debt;
        }

        if(Depression > highestStatValue)
        {
            highestStat = PlayerStat.Depression;
            highestStatValue = Depression;
        }

        if (Disease > highestStatValue)
        {
            highestStat = PlayerStat.Disease;
            highestStatValue = Disease;
        }

        if (Distress > highestStatValue)
        {
            highestStat = PlayerStat.Distress;
            highestStatValue = Distress;
        }

        if (Decay > highestStatValue)
        {
            highestStat = PlayerStat.Decay;
            highestStatValue = Decay;
        }

        return highestStat;
    }

    public int GetStatVal(PlayerStat stat)
    {
        switch (stat)
        {
            case (PlayerStat.Debt):
                {
                    return Debt;
                }
            case (PlayerStat.Depression):
                {
                    return Depression;
                }
            case (PlayerStat.Disease):
                {
                    return Disease;
                }
            case (PlayerStat.Distress):
                {
                    return Distress;
                }
            case (PlayerStat.Decay):
                {
                    return Decay;
                }
            default:
                {
                    return -1;
                }
        }
    }

}

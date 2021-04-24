using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuInfo : MonoBehaviour
{
    private static MainMenuInfo _instance;
    public static MainMenuInfo Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new MainMenuInfo();
            }

            return _instance;
        }
    }

    public int debt = 0;
    public int distress = 0;
    public int depression = 0;
    public int disease = 0;

    private void Start()
    {
        DontDestroyOnLoad(this);
        Reset();
    }

    public void Reset()
    {
        debt = 0;
        distress = 0;
        depression = 0;
        disease = 0;
    }
}

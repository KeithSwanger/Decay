using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController _gameController;
    public static GameController Instance
    {
        get
        {
            if(_gameController == null)
            {
                _gameController = new GameController();
            }

            return _gameController;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

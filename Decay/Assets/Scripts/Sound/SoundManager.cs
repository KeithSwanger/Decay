using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static SoundManager _instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject i = new GameObject();
                _instance = i.AddComponent<SoundManager>();
                i.name = "Sound Manager";
            }

            return _instance;
        }
    }

    private void Awake()
    {
        GameObject.DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

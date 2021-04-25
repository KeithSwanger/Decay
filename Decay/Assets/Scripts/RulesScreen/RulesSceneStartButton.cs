using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RulesSceneStartButton : MonoBehaviour
{
    public FadeOutAndLoadScene fade;
    public Button button;


    private void Awake()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        fade.StartFading();
    }
}

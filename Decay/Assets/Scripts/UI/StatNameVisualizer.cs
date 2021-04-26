using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class StatNameVisualizer : MonoBehaviour
{
    public PlayerStat stat;
    public TMP_Text text;
    public float fontSizeOnStatChange = 20;
    float originalFontSize;

    public Color colorOnStatChangePositive = Color.red;
    public Color colorOnStatChangeNegative = Color.green;
    Color originalColor;

    GameController gameController;

    private void Awake()
    {
        gameController = GameController.Instance;
        originalColor = text.color;
        originalFontSize = text.fontSize;
    }

    private void Start()
    {
        gameController.player.Stats.StatChanged += OnStatChanged;
    }

    private void Update()
    {
        if (text.color != originalColor)
        {
            text.color = Color.Lerp(text.color, originalColor, 2f * Time.deltaTime);
        }

        if(text.fontSize != originalFontSize)
        {
            float size = text.fontSize - Time.deltaTime * 3f;

            if(size < originalFontSize)
            {
                size = originalFontSize;
            }

            text.fontSize = size;
        }
    }

    private void OnStatChanged(PlayerStat changedStat, int oldValue, int newValue)
    {
        if (this.stat == changedStat)
        {
            if (newValue < oldValue)
            {
                text.fontSize = fontSizeOnStatChange;
                text.color = colorOnStatChangeNegative;
            }
            else if (newValue > oldValue)
            {
                text.fontSize = fontSizeOnStatChange;
                text.color = colorOnStatChangePositive;
            }
        }

    }
}

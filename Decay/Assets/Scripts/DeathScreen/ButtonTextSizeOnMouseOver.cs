using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonTextSizeOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public EventSystem eventSystem;
    public Button button;
    public TMP_Text text;
    public float fontSizeOnMouzeOver = 50f;
    float normalFontSize;

  

    void Awake()
    {
        normalFontSize = text.fontSize;
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        text.fontSize = fontSizeOnMouzeOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text.fontSize = normalFontSize;
    }
}

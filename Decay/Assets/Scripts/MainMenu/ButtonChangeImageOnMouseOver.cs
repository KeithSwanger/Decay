using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonChangeImageOnMouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image image;
    public Sprite spriteDefault;
    public Sprite spriteOnMouseOver;

    void Awake()
    {
        image.sprite = spriteDefault;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = spriteOnMouseOver;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = spriteDefault;
    }
}

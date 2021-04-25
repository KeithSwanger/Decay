using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public string name;
    public List<Sprite> statBarSprites;
    public Image image;

    public void SetSprite(int index)
    {
        if(index >= statBarSprites.Count)
        {
            Debug.LogError("Sprite index out of range");
            return;
        }

        image.sprite = statBarSprites[index];
    }
}

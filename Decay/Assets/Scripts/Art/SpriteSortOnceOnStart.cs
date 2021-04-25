using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSortOnceOnStart : MonoBehaviour
{
    public SpriteRenderer sr;
    public int offset = 0;

    private void Awake()
    {
        if (sr == null)
        {
            sr = GetComponent<SpriteRenderer>();
        }
    }

    private void Start()
    {
        sr.sortingOrder = -Mathf.FloorToInt((gameObject.transform.position.y + offset) * 1000);
    }
}

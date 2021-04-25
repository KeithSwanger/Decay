using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSortOnLateUpdate : MonoBehaviour
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

    // Update is called once per frame
    void LateUpdate()
    {
        sr.sortingOrder = -Mathf.FloorToInt((gameObject.transform.position.y + offset) * 1000);
    }
}
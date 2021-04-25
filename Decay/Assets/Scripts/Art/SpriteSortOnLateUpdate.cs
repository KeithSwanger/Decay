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
        sr.sortingOrder = -Mathf.FloorToInt((((gameObject.transform.position.y) * 100f + offset) / 100000f) * 32000f);

        //int newOrder;
        //if (gameObject.transform.position.y > 0)
        //{
        //    newOrder = -Mathf.FloorToInt((gameObject.transform.position.y + offset) * 1000);
        //}

        //if (newOrder > 0)
        //{
        //    newOrder *= -1;
        //}
        //sr.sortingOrder = newOrder;
    }
}
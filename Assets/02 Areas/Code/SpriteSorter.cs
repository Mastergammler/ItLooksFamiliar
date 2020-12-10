using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SpriteSorter : MonoBehaviour
{
    private SpriteRenderer mRend;
    void Start()
    {
        mRend = GetComponent<SpriteRenderer>();
        mRend.sortingOrder = (int)(transform.position.y * -100) + (int)mRend.sprite.bounds.min.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

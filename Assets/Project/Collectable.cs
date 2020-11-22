using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Collectable : MonoBehaviour, ICollectable
{
    //TODO: How would i handle the collider then?
    public CollectableSO ItemDef; 
    private SpriteRenderer mRenderer;

    public CollectableSO OnCollect()
    {
        return ItemDef;
    }

    // Start is called before the first frame update
    void Start()
    {
       mRenderer = GetComponent<SpriteRenderer>(); 
       mRenderer.sprite = ItemDef.Image;
    }
}

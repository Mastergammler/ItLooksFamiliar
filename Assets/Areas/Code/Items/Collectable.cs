using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Items
{


    [RequireComponent(typeof(SpriteRenderer))]
    public class Collectable : MonoBehaviour, ICollectable
    {
        //TODO: How would i handle the collider then?
        public CollectableSO ItemDef;
        private SpriteRenderer mRenderer;
        private bool isCollected = false;
        public bool IsCollected => isCollected;

        public CollectableSO OnCollect()
        {
            if (isCollected) return null;
            isCollected = true;
            return ItemDef;
        }

        void Start()
        {
            mRenderer = GetComponent<SpriteRenderer>();
            mRenderer.sprite = ItemDef.Image;
        }
    }

}
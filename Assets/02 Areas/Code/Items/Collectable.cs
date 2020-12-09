using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Items
{


    [RequireComponent(typeof(SpriteRenderer))]
    public class Collectable : MonoBehaviour, ICollectable
    {
        //##################
        //##    EDITOR    ##
        //##################

        public CollectableSO ItemDef;

        //###############
        //##  MEMBERS  ##
        //###############

        private SpriteRenderer mRenderer;
        private bool isCollected = false;

        //#################
        //##  INTERFACE  ##
        //#################

        public CollectableSO OnCollect()
        {
            if (isCollected) return null;
            isCollected = true;
            return ItemDef;
        }

        //################
        //##    MONO    ##
        //################

        void Start()
        {
            mRenderer = GetComponent<SpriteRenderer>();
            mRenderer.sprite = ItemDef.Image;
        }

        //#################
        //##  ACCESSORS  ##
        //#################

        public bool IsCollected { set { isCollected = value;} get { return isCollected; }}
    }

}
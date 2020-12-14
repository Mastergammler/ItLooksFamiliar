using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ItLooksFamiliar.UI
{
    public class DropSpot : MonoBehaviour, IDropHandler
    {
        //###############
        //##  MEMBERS  ##
        //###############
        private InventoryUI mInvUI;

        //################
        //##    MONO    ##
        //################
        void Start()
        {
            mInvUI = GetComponentInParent<InventoryUI>();
        }

        //######################
        //##  I DROP HANDLER  ##
        //######################

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                GameObject draggedItem = eventData.pointerDrag;
                InventoryUI originInv = draggedItem.GetComponentInParent<InventoryUI>();
                InventoryUI targetInv = transform.GetComponentInParent<InventoryUI>();

                int originIndex = draggedItem.transform.parent.GetSiblingIndex();
                int targetIndex = transform.GetSiblingIndex();
                CollectableSO newItem = originInv.RemoveItemFrom(originIndex);
                CollectableSO oldItem = targetInv.RemoveItemFrom(targetIndex);

                if(newItem != null) targetInv.AddItem(newItem,targetIndex);
                if(oldItem != null) originInv.AddItem(oldItem,originIndex);
            }
        }
    }

}
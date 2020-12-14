using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ItLooksFamiliar.UI
{
    public class InventorySlot : AnimatedGridElement
    {
        //###############
        //##  MEMBERS  ##
        //###############

        protected InventoryUI mParentController;

        //################
        //##    MONO    ##
        //################

        void Start()
        {
            mParentController = transform.parent.GetComponent<InventoryUI>();
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                int ownIndex = transform.GetSiblingIndex();
                transform.GetComponentInParent<ItemTooltip>().OnPointerExit(eventData);
                mParentController.RemoveItemFromSlot(ownIndex);
            }
        }
    }

}
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

        //#################
        //##  INTERFACE  ##
        //#################

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                int ownIndex = transform.GetSiblingIndex();
                mParentController.RemoveItemFromSlot(ownIndex);
            }
        }

        //################
        //##    MONO    ##
        //################

        void Start()
        {
            mParentController = transform.parent.GetComponent<InventoryUI>();
        }
    }

}
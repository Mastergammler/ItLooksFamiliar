using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Items;
using MgSq.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ItLooksFamiliar.UI
{

    public class ItemTooltip : TooltipTrigger
    {
        //###############
        //##  MEMBERS  ##
        //###############

        private CollectableSO mObjectValues;


        //#################
        //##  INTERFACE  ##
        //#################

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (mObjectValues != null)
            {
                TooltipHeader = mObjectValues.Name;
                TooltipContent = mObjectValues.Description;
                base.OnPointerEnter(eventData);
            }
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (mObjectValues != null)
            {
                base.OnPointerExit(eventData);
            }
        }

        //#################
        //##  ACCESSORS  ##
        //#################

        public void UpdateTooltipMessage(CollectableSO newObject)
        {
            mObjectValues = newObject;
        }
    }

}
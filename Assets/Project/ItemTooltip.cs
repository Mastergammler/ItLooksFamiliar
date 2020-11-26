using System.Collections;
using System.Collections.Generic;
using MgSq.UI;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ICollectable))]
public class ItemTooltip : TooltipTrigger
{
    private CollectableSO mObjectValues;


    public void UpdateTooltipMessage(CollectableSO newObject)
    {
        mObjectValues = newObject;
    }
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
        if(mObjectValues != null)
        {
            base.OnPointerExit(eventData);
        }
    }
}

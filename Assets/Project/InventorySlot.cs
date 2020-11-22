using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : AnimatedGridElement 
{
    public override void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            int ownIndex = transform.GetSiblingIndex();
            mParentController.RemoveItemFromSlot(ownIndex);
        }
    }

    private InventoryUI mParentController;
    // Start is called before the first frame update
    void Start()
    {
        mParentController = transform.parent.GetComponent<InventoryUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

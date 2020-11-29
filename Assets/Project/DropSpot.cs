using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSpot : MonoBehaviour, IDropHandler
{
    private ShipInventoryUI mInvUI;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            GameObject draggedItem = eventData.pointerDrag;
            int itemIndex = draggedItem.transform.parent.GetSiblingIndex();
            int currentIndex = transform.GetSiblingIndex();
            mInvUI.AddItem(currentIndex,itemIndex);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       mInvUI = GetComponentInParent<ShipInventoryUI>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

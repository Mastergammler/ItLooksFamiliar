using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public int InventorySlots = 8; 
    private Image[] mChildImages;
    private ItemTooltip[] mTooltips;

    //todo: fix direct player access
    public GameObject InventoryHolder;
    protected IInventory mInv;
    void Start()
    {
        Init();
    }
    protected void Init()
    {
        mChildImages = new Image[InventorySlots];
        mTooltips = new ItemTooltip[InventorySlots];
        for (int i = 0; i < InventorySlots; i++)
        {
            mChildImages[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();
            mTooltips[i] = transform.GetChild(i).GetComponent<ItemTooltip>();
        }

        mInv = InventoryHolder.GetComponent<IInventory>();
        mInv.OnInventoryChanged += UpdateInventoryUI;
    }

    public virtual void RemoveItemFromSlot(int slotNo)
    {
        mInv.RemoveItem(slotNo);
    }

    private void UpdateInventoryUI(object sender, InventoryObject e)
    {
        if (e.Item == null)
        {
            mChildImages[e.SlotNo].sprite = null;
            mChildImages[e.SlotNo].color = new Color(0, 0, 0, 0);
        }
        else
        {
            mChildImages[e.SlotNo].sprite = e.Item.Image;
            mChildImages[e.SlotNo].color = new Color(1, 1, 1, 1);
        }
        mTooltips[e.SlotNo].UpdateTooltipMessage(e.Item);
    }
}

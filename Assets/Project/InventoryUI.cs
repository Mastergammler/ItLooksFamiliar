using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //todo: initialize with dynamic inventory count
    private Image[] mChildImages; 
    //todo: fix direct player access
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        mChildImages = new Image[8];
        for(int i = 0; i < 8; i++)
        {
            mChildImages[i] = transform.GetChild(i).GetChild(0).GetComponent<Image>();
        }

        IInventory inv = Player.GetComponent<IInventory>();
        inv.OnInventoryChanged += UpdateInventoryUI;
    }

    private void UpdateInventoryUI(object sender, InventoryObject e)
    {
        mChildImages[e.SlotNo].sprite = e.Item.Image;
        if(mChildImages[e.SlotNo] != null)
            mChildImages[e.SlotNo].color = new Color(1,1,1,1);
        else
            mChildImages[e.SlotNo].color = new Color(0,0,0,0);
    }
}

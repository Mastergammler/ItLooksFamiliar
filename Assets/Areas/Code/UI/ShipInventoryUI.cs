﻿using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Core;
using ItLooksFamiliar.Items;
using ItLooksFamiliar.Sound;
using UnityEngine;

namespace ItLooksFamiliar.UI
{

    public class ShipInventoryUI : InventoryUI
    {
        public GameObject PlayerInventory;

        [SerializeField]
        private float ShowTooltipTime = 2f;

        private IInventory mPlayerInv;
        private ShipTester mTester;

        private void Start()
        {
            base.Init();
            mPlayerInv = PlayerInventory.GetComponent<IInventory>();
            mTester = GetComponent<ShipTester>();
        }

        public void InvokeShipFunctionTest()
        {
            RepairItems curItems = new RepairItems(
                mInv.GetItemInSlot(0),
                mInv.GetItemInSlot(1),
                mInv.GetItemInSlot(2),
                mInv.GetItemInSlot(3),
                mInv.GetItemInSlot(4));
            Errors curError = ShipTester.TestShipFunction(curItems);
            string errorMsg = mTester.GetErrorMessage(curError);
            HintSystem.Instance.Show(errorMsg);
            UIManager.Instance.HideShipHint();
            if (curError == Errors.NO_ERRORS)
            {
                UIManager.Instance.InitateWorldTransitino();
                SoundManager.Instance.PlaySound("Success");
            }
            else { SoundManager.Instance.PlaySound("Error"); }
        }
        public override void RemoveItemFromSlot(int slotNo)
        {
            CollectableSO item = mInv.GetItemInSlot(slotNo);
            mInv.RemoveItem(slotNo);
            bool succ = mPlayerInv.AddItem(item);
            SoundManager.Instance.PlaySound("Uninstall");
        }

        public void AddItem(int targetSlotNo, int itemSlotNo)
        {
            CollectableSO item = mPlayerInv.GetItemInSlot(itemSlotNo);
            bool succ = mInv.AddItem(targetSlotNo, item);
            mPlayerInv.RemoveItem(itemSlotNo);
            SoundManager.Instance.PlaySound("Install");
        }
    }

}
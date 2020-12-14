using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Core;
using ItLooksFamiliar.Environment;
using ItLooksFamiliar.Items;
using ItLooksFamiliar.Sound;
using UnityEngine;

namespace ItLooksFamiliar.UI
{

    public class ShipInventoryUI : InventoryUI
    {
        //##################
        //##    EDITOR    ##
        //##################

        public GameObject PlayerInventory;

        [SerializeField]
        private float ShowTooltipTime = 2f;

        [SerializeField]
        private ShipTransition Ship;

        //###############
        //##  MEMBERS  ##
        //###############

        private IInventory mPlayerInv;

        //################
        //##    MONO    ##
        //################

        private void Start()
        {
            base.Init();
            mPlayerInv = PlayerInventory.GetComponent<IInventory>();
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public void InvokeShipFunctionTest()
        {
            RepairItems curItems = new RepairItems(
                mInv.GetItemInSlot(0),
                mInv.GetItemInSlot(1),
                mInv.GetItemInSlot(2),
                mInv.GetItemInSlot(3),
                mInv.GetItemInSlot(4));

            Errors curError = ShipTester.TestShipFunction(curItems);
            string errorMsg = ShipTester.GetErrorMessage(curError, curItems);

            HintSystem.Instance.Show(errorMsg);
            UIManager.Instance.ScheduleHidingShipHint();
            
            testResultAction(curError);
        }

        private void testResultAction(Errors curError)
        {
            switch (curError)
            {
                case Errors.NO_ERRORS:
                    SoundManager.Instance.PlaySound("Success");
                    Ship.StartTransition();
                    break;
                default:
                    SoundManager.Instance.PlaySound("Error");
                    break;
            }
        }

        //###################
        //##  I INVENTORY  ##
        //###################

        public override void RemoveItemFromSlot(int slotNo)
        {
            CollectableSO item = mInv.GetItemInSlot(slotNo);
            if (item != null)
            {
                bool succ = mPlayerInv.AddItem(item);
                if (succ)
                {
                    mInv.RemoveItem(slotNo);
                    SoundManager.Instance.PlaySound("Uninstall");
                }
            }
        }

        public void AddItem(int targetSlotNo, int itemSlotNo)
        {
            CollectableSO item = mPlayerInv.GetItemInSlot(itemSlotNo);
            CollectableSO curItem = mInv.GetItemInSlot(targetSlotNo);
            mInv.RemoveItem(targetSlotNo);
            mInv.AddItem(targetSlotNo, item);
            mPlayerInv.RemoveItem(itemSlotNo);

            SoundManager.Instance.PlaySound("Install");
            if (curItem != null)
            {
                mPlayerInv.AddItem(curItem);
            }
        }
    }

}
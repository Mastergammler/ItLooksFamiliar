using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipInventoryUI : InventoryUI
{
    public GameObject PlayerInventory;

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
        string errorMsg = mTester.GetErrorMessage(ShipTester.TestShipFunction(curItems));
        HintSystem.Instance.Show(errorMsg);
        StartCoroutine(HideAfterDelay(2f));
    }
    private IEnumerator HideAfterDelay(float dealy)
    {
        yield return new WaitForSeconds(dealy);
        HintSystem.Instance.Hide();
        yield return null;
    }
    public override void RemoveItemFromSlot(int slotNo)
    {
        CollectableSO item = mInv.GetItemInSlot(slotNo);
        mInv.RemoveItem(slotNo);
        bool succ = mPlayerInv.AddItem(item);
    }

    public void AddItem(int targetSlotNo,int itemSlotNo)
    {
        CollectableSO item = mPlayerInv.GetItemInSlot(itemSlotNo);
        bool succ = mInv.AddItem(targetSlotNo,item);
        mPlayerInv.RemoveItem(itemSlotNo);
    }
}

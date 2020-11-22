using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStackableInventory : MonoBehaviour, IInventory
{
    [SerializeField]
    private int IventorySlots = 8;
    private Dictionary<int,CollectableSO> mInventory = new Dictionary<int, CollectableSO>();

    public event EventHandler<InventoryObject> OnInventoryChanged;
    [SerializeField]
    private GameObject ItemPrefab;

    //#################
    //##  INTERFACE  ##
    //#################

    public bool AddItem(CollectableSO item)
    {
        int nextSlot = FindNextOpenSlot();
        if( nextSlot != -1)
        {
            mInventory.Add(nextSlot,item);
            OnInventoryChanged.Invoke(this,new InventoryObject(nextSlot,item));
            return true;
        }
        return false;
    }

    private int FindNextOpenSlot()
    {
        for(int i = 0; i < IventorySlots; i ++ )
        {
            if( ! mInventory.ContainsKey(i))
                return i;
        }
        return -1;
    }


    // Will return null if empty
    public CollectableSO GetItemInSlot(int slotNo)
    {
        CollectableSO value = null;
        mInventory.TryGetValue(slotNo,out value);
        return value;
    }

    public void RemoveItem(CollectableSO item)
    {
        int slotNo = -1;
        if(mInventory.ContainsValue(item))
        {
            foreach(var i in mInventory)
            {
                if(i.Value.Equals(item)) 
                {

                    slotNo = i.Key;
                    break;
                }
            }
            mInventory.Remove(slotNo);
            OnInventoryChanged.Invoke(this,new InventoryObject(slotNo));
        }
    }

    public void RemoveItem(int slotNo)
    {
        if(mInventory.ContainsKey(slotNo))
        {
            CollectableSO coll = null;
            mInventory.TryGetValue(slotNo,out coll);
            Collectable script = ItemPrefab.GetComponent<Collectable>();
            script.ItemDef = coll;
            float val = UnityEngine.Random.Range(-2.0f,2.0f);
            Vector3 v3 = new Vector3(val,1,0);
            Instantiate(ItemPrefab,transform.position + v3,Quaternion.identity);
            mInventory.Remove(slotNo);
            OnInventoryChanged.Invoke(this,new InventoryObject(slotNo));
        }
    }
}

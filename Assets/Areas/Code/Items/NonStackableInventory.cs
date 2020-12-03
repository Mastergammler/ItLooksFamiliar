using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ItLooksFamiliar.Items
{

    public class NonStackableInventory : MonoBehaviour, IInventory
    {
        //##################
        //##    EDITOR    ##
        //##################

        [SerializeField]
        private int IventorySlots = 8;

        [SerializeField]
        private GameObject ItemPrefab;

        //###############
        //##  MEMBERS  ##
        //###############
        private Dictionary<int, CollectableSO> mInventory = new Dictionary<int, CollectableSO>();
        public event EventHandler<InventoryObject> OnInventoryChanged;

        //#################
        //##  INTERFACE  ##
        //#################

        public bool AddItem(CollectableSO item)
        {
            int nextSlot = FindNextOpenSlot();
            if (nextSlot != -1)
            {
                mInventory.Add(nextSlot, item);
                OnInventoryChanged.Invoke(this, new InventoryObject(nextSlot, item));
                return true;
            }
            return false;
        }

        public bool AddItem(int slotNo, CollectableSO item)
        {
            if (mInventory.ContainsKey(slotNo)) return false;
            mInventory.Add(slotNo, item);
            OnInventoryChanged.Invoke(this, new InventoryObject(slotNo, item));
            return true;
        }

        private int FindNextOpenSlot()
        {
            for (int i = 0; i < IventorySlots; i++)
            {
                if (!mInventory.ContainsKey(i))
                    return i;
            }
            return -1;
        }


        // Will return null if empty
        public CollectableSO GetItemInSlot(int slotNo)
        {
            CollectableSO value = null;
            mInventory.TryGetValue(slotNo, out value);
            return value;
        }

        public void RemoveItem(CollectableSO item)
        {
            int slotNo = -1;
            if (mInventory.ContainsValue(item))
            {
                foreach (var i in mInventory)
                {
                    if (i.Value.Equals(item))
                    {
                        slotNo = i.Key;
                        break;
                    }
                }
                mInventory.Remove(slotNo);
                OnInventoryChanged.Invoke(this, new InventoryObject(slotNo));
            }
        }

        public void RemoveItem(int slotNo)
        {
            if (mInventory.ContainsKey(slotNo))
            {
                mInventory.Remove(slotNo);
                OnInventoryChanged.Invoke(this, new InventoryObject(slotNo));
            }
        }
    }
}
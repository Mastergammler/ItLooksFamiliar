using System;
using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Sound;
using UnityEngine;

namespace ItLooksFamiliar.Items
{

    [RequireComponent(typeof(ISoundPlayback))]
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
        private ISoundPlayback mSound;
        public event EventHandler<InventoryObject> OnInventoryChanged;

        private Predicate<CollectableSO> itemNotNull = item => item != null;
        private Predicate<int> slotAvailable = slotNo => slotNo != -1;

        //################
        //##    MONO    ##
        //################

        private void Awake() 
        {
            mSound = GetComponent<ISoundPlayback>();
        }

        //#################
        //##  INTERFACE  ##
        //#################

        public bool AddItem(CollectableSO item)
        {
            int slot = FindNextOpenSlot();

            if (itemNotNull(item) && slotAvailable(slot))
            {
                mInventory.Add(slot, item);
                OnInventoryChanged.Invoke(this, new InventoryObject(slot, item));
                mSound.Play("Add");

                return true;
            }
            return false;
        }
        public bool AddItem(int slotNo, CollectableSO item)
        {
            Predicate<int> slotNoEmpty = slotNo =>  mInventory.ContainsKey(slotNo);

            if (itemNotNull(item) && slotNoEmpty(slotNo)) 
            {
                mInventory.Add(slotNo, item);
                OnInventoryChanged.Invoke(this, new InventoryObject(slotNo, item));
                mSound.Play("Add");

                return true;
            }
            return false;
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

        public CollectableSO GetItemInSlot(int slotNo)
        {
            CollectableSO value = null;
            mInventory.TryGetValue(slotNo, out value);
            return value;
        }
 
        public void RemoveItem(CollectableSO item)
        {
            RemoveItem(FindIndexFor(item));
        }

        private int FindIndexFor(CollectableSO item)
        {
            foreach(var cur in mInventory)
            {
                if(cur.Value.Equals(item))
                    return cur.Key;
            }
            return -1;
        }

        public void RemoveItem(int slotNo)
        {
            if (mInventory.ContainsKey(slotNo))
            {
                mInventory.Remove(slotNo);
                OnInventoryChanged.Invoke(this, new InventoryObject(slotNo));
                mSound.Play("Remove");
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using ItLooksFamiliar.Items;
using ItLooksFamiliar.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace ItLooksFamiliar.UI
{
    public class InventoryUI : MonoBehaviour
    {
        //##################
        //##    EDITOR    ##
        //##################

        public int InventorySlots = 8;
        public GameObject ItemPrefab;
        public GameObject InventoryHolder;

        //#################
        //##  CONSTANTS  ##
        //#################

        public static readonly Color COL_TRANSPARENT = new Color(0,0,0,0);
        public static readonly Color COL_WHITE = new Color(1,1,1,1);

        //###############
        //##  MEMBERS  ##
        //###############

        private Image[] mChildImages;
        private ItemTooltip[] mTooltips;
        protected IInventory mInv;

        //################
        //##    MONO    ##
        //################

        void Start()
        {
            Init();
        }

        //###############
        //##  METHODS  ##
        //###############

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

        private void UpdateInventoryUI(object sender, InventoryObject e)
        {
            if (e.Item) setSpriteForSlot(e.SlotNo,e.Item.Image,COL_WHITE);
            else        setSpriteForSlot(e.SlotNo,null,COL_TRANSPARENT);             
            
            mTooltips[e.SlotNo].UpdateTooltipMessage(e.Item);
        }

        private void setSpriteForSlot(int slotNo,Sprite sprite, Color color)
        {
            mChildImages[slotNo].sprite = sprite;
            mChildImages[slotNo].color = color;
        }

        //###################
        //##  I INVENTORY  ##
        //###################

        public CollectableSO RemoveItemFrom(int slotNo)
        {
            CollectableSO item = mInv.GetItemInSlot(slotNo);
            mInv.RemoveItem(slotNo);
            return item;
        }

        public void AddItem(CollectableSO item, int slotNo)
        {
            if (!mInv.AddItem(slotNo, item)) Debug.LogWarning("Item in slot no " + slotNo + " does already exist!!");
        }

        //todo ho to handle the instatiation then? -> it's now a different method for right click
        public virtual void RemoveItemFromSlot(int slotNo)
        {
            Collectable script = ItemPrefab.GetComponent<Collectable>();
            script.ItemDef = mInv.GetItemInSlot(slotNo);
            if (script.ItemDef != null)
            {
                float val = UnityEngine.Random.Range(-2.0f, 2.0f);
                Vector3 v3 = new Vector3(val, 1, 0);
                Instantiate(ItemPrefab, InventoryHolder.transform.position + v3, Quaternion.identity);

                mInv.RemoveItem(slotNo);
                SoundManager.Instance.PlaySound("ThrowAway");
            }
        }
    }

}
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : LoadAutoComponents
{
    [Header("Inventory")]
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;

    public List<ItemInventory> Items => items;
    private void Start()
    {
        AddItem(ItemCode.Sword,1);
        AddItem(ItemCode.IronOre,7);
        AddItem(ItemCode.GoldOre,7);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {

        ItemProfileSO itemProfileSO = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExit;

        // for update them item khi 1 stack full
        for (int i = 0; i < this.maxSlot;i++)
        {
            itemExit = this.GetItemNotFullStack(itemCode);

            // check xem ItemInventory co chua, neu chua co thi tao
            if(itemExit == null)
            {
                if (this.IsInventoryFull()) return false;
                itemExit = this.CreateEmptyItem(itemProfileSO);
                this.items.Add(itemExit);
            }


            // ItemInventory da co => cong So luong 
            newCount = itemExit.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExit);

            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExit.itemCount;
                newCount = itemExit.itemCount + addMore;
                addRemain -= addMore;
            }
            else{
                addRemain -= newCount;
            }

            itemExit.itemCount = newCount;
            if (addRemain < 1) break;
        }
        return true;
    }

    public virtual bool AddItem(ItemInventory itemInventory)
    {

        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfileSO = itemInventory.itemProfile;
        ItemCode itemCode = itemProfileSO.itemCode;
        ItemType itemType = itemProfileSO.itemType;
        if (itemType == ItemType.Equiment) return this.AddEquiment(itemInventory);

        return this.AddItem(itemCode,addCount);
    }

    public virtual bool AddEquiment(ItemInventory itemPicked)
    {
        if (this.IsInventoryFull()) return false;
        ItemInventory item = itemPicked.Clone();
        this.items.Add(item);
        return true;
    }
    protected virtual bool IsInventoryFull()
    {
        if (this.items.Count >= this.maxSlot) return true;
        return false;
    }


    // lay max stack

    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }

    // lay thong tin itemCode trong file Resources phan Scripttableobject Item
    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    // lay item neu khong full stack
    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemCode != itemInventory.itemProfile.itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }

        return null;
    }

    // check full stack chua
    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }


    // check xem neu chua co item thi create
    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfileSO)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfileSO,
            maxStack = itemProfileSO.defaultMaxStack,
        };

        return itemInventory;
    }


    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }

    public virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }
        return totalCount;
    }

    // Ham tru item

    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;

        for (int i = this.items.Count - 1; i >= 0;i--)
        {
            if (deductCount <= 0) break;

            itemInventory = this.items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            if(deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = deductCount;
                deductCount = 0;
            }
            itemInventory.itemCount -= deduct;
        }
        this.ClearEmptySlot();

    }
    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for (int i = 0; i < this.items.Count;i++)
        {
            itemInventory = this.items[i];
            if(itemInventory.itemCount == 0) this.items.RemoveAt(i);
        }
    }





    //// Additem 
    //public virtual bool AddResource(ItemCode itemCode, int addCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //    int newCount = itemInventory.itemCount + addCount;
    //    if (newCount > itemInventory.maxStack)
    //    {
    //        Debug.LogError("Full pack");
    //        return false;
    //    }

    //    itemInventory.itemCount = newCount;
    //    return true;

    //}
    //public virtual bool AddEquiment(ItemInventory itemInventory)
    //{
    //    Debug.Log("AddEquiment");
    //    itemInventory.itemCount = 1;
    //    return true;
    //}

    ////method check xem con item de tru khong + tru item luon
    //public virtual bool DeductItem(ItemCode itemCode, int deductCount)
    //{
    //    // goi item ItemCode (Quan li enum obj item)
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //    int newCount = itemInventory.itemCount - deductCount;
    //    if (newCount < 0) return false;

    //    itemInventory.itemCount = newCount;
    //    return true;
    //}

    //// method check xem con item de tru khong => tac dung co the nang cap do
    //public virtual bool TryDeductItem(ItemCode itemCode, int deductCount)
    //{
    //    ItemInventory itemInventory = this.GetItemByCode(itemCode);
    //    int newCount = itemInventory.itemCount - deductCount;
    //    if (newCount < 0) return false;

    //    return true;
    //}


    //public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    //{
    //    ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
    //    if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
    //    return itemInventory;
    //}

    //protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    //{
    //    var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
    //    foreach (ItemProfileSO profile in profiles)
    //    {
    //        if (profile.itemCode != itemCode) continue;
    //        ItemInventory itemInventory = new ItemInventory
    //        {
    //            itemProfile = profile,
    //            maxStack = profile.defaultMaxStack
    //        };
    //        this.items.Add(itemInventory);
    //        return itemInventory;
    //    }

    //    return null;
    //}

}

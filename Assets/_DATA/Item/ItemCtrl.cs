using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : LoadAutoComponents
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        itemDespawn = GetComponentInChildren<ItemDespawn>();
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.itemInventory.itemCount = 1;

    }
}

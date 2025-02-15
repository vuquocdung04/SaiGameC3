using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    static UIInventory instance;
    public static UIInventory Instance => instance;
    protected bool isOpen = false; 
    protected override void Awake()
    {
        if (UIInventory.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        UIInventory.instance = this;
    }
    protected virtual void Start()
    {
        InvokeRepeating(nameof(ShowItem),1,1);
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.uIInventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.uIInventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;
        //xoa het item

        this.ClearItem();
        List<ItemInventory> items = PlayerCtrl.Instance.ShipCtrl.Inventory.Items;
        UIInventorySpawner spawner = this.UIInventoryCtrl.UIInventorySpawner;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }

    }

    protected virtual void ClearItem()
    {
        this.UIInventoryCtrl.UIInventorySpawner.ClearItem();
    }
    

}

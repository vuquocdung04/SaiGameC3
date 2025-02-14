using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : LoadAutoComponents
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
        //this.Close();
    }

    protected virtual void FixedUpdate()
    {

    }



    // ki thuat double click la close 
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true; 
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen =false;
    }


    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;
        float itemCount = PlayerCtrl.Instance.ShipCtrl.Inventory.Items.Count;
        Debug.Log("itemCount :" + itemCount);

    }
}

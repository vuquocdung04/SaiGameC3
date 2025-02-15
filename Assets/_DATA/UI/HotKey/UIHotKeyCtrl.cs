using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : LoadAutoComponents
{
    static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    public List<ItemSlot> itemSlots;

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        UIHotKeyCtrl.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemSlots();
    }

    protected virtual void LoadItemSlots()
    {
        if (this.itemSlots.Count > 0) return;
        ItemSlot[] arrSlots = GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(arrSlots); // addrange chuyen tu arr thanh list


    }


}

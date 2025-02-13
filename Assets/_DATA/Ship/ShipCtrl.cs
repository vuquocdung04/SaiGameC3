using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AbilitiObjectCtrl
{
    [Header("Inventory")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override string GetObjectTypeName()
    {
        return ObjType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = GetComponentInChildren<Inventory>();
    }
}

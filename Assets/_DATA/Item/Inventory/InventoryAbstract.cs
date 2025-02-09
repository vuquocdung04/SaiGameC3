using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : LoadAutoComponents
{
    [Header("InventoryAbstract")]
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = GetComponentInParent<Inventory>();
    }
}

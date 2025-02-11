using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{

    // ham pick up item
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemCode itemCode = itemPickupable.GetItemCode();
        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.playerCtrl.ShipCtrl.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }

    }
}

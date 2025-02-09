using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{

    // ham pick up item
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        ItemCode itemCode = itemPickupable.GetItemCode();
        if (this.playerCtrl.ShipCtrl.Inventory.AddItem(itemCode,1))
        {
            itemPickupable.Picked();
        }

    }
}

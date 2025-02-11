using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDrop : InventoryAbstract
{

    private void Start()
    {
        Invoke(nameof(Test),5);
    }
    protected virtual void Test()
    {
        this.DropItemIndex(0);
    }

    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Debug.LogError(itemInventory.upgradeLevel);

        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        ItemDropSpawner.Instance.Drop(itemInventory,dropPos,Quaternion.identity);
        this.inventory.Items.Remove(itemInventory);
    }
}

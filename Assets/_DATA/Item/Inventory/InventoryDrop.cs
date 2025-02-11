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
        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        this.DropItemIndex(0, dropPos, Quaternion.identity);
    }

    protected virtual void DropItemIndex(int itemIndex, Vector3 dropPos, Quaternion dropRot)
    {
        ItemInventory itemInventory = this.inventory.Items[itemIndex];
        Debug.LogError(itemInventory.upgradeLevel);


        ItemDropSpawner.Instance.Drop(itemInventory,dropPos, dropRot);
        this.inventory.Items.Remove(itemInventory);
    }
}

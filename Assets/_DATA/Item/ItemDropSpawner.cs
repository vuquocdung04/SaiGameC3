using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        ItemDropSpawner.instance = this;
    }


    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        if (dropList.Count < 1) return;

        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(),pos,rot);
        if (itemDrop == null) return;
        Debug.LogError(itemDrop.gameObject.name);
        itemDrop.gameObject.SetActive(true);
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;

        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        Debug.LogError(itemDrop.gameObject.name);
        itemDrop.gameObject.SetActive(true);

        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventory(itemInventory);
        return itemDrop;
    }
}

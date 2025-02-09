using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner<ItemDropSpawner>
{
    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(),pos,rot);
        if (itemDrop == null) return;
        Debug.LogError(itemDrop.gameObject.name);
        itemDrop.gameObject.SetActive(true);
    }
}

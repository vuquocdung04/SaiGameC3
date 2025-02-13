using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;


    [SerializeField] protected float gameDropRate = 1f;
    protected override void Awake()
    {
        if (ItemDropSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        ItemDropSpawner.instance = this;
    }


    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
    {

        List<ItemDropRate> dropItems = new List<ItemDropRate>();
        if (dropList.Count < 1) return null;

        dropItems = this.DropItems(dropList);

        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemCode itemCode = itemDropRate.itemSO.itemCode;
            Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
            if (itemDrop == null) continue;
            Debug.LogError(itemDrop.gameObject.name);
            itemDrop.gameObject.SetActive(true);
        }
        return dropItems;
    }
    
    public virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        float rate, itemRate;
        foreach (ItemDropRate item in items) 
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate * this.gameDropRate;
            if(rate <= itemRate)
            {
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    public virtual Transform DropFromInventory(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
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

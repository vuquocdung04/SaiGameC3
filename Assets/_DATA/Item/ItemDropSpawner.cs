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
        int itemDropMore;
        foreach (ItemDropRate item in items) 
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate/100000f * this.GameDropRate();

            Debug.Log("==============");
            Debug.Log("itemName: "+ item.itemSO.itemName);
            Debug.Log("rate: "+itemRate +" /" + rate);

            itemDropMore = Mathf.FloorToInt(itemRate);

            if(itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore;i++)
                {
                    droppedItems.Add(item);
                }
            }

            if(rate <= itemRate)
            {
                Debug.Log("DRoped");
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }
    // method dieu chinh ti le drop
    protected virtual float GameDropRate()
    {
        float dropRateFromItems = 0.5f;
        return this.gameDropRate + dropRateFromItems;
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

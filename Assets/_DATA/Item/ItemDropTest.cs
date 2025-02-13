using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : LoadAutoComponents
{
    public JunkCtrl junkCtrl;
    public int dropCount = 0;

    public List<ItemDropCount> dropCountItems= new List<ItemDropCount>();
    protected virtual void Start()
    {
        InvokeRepeating(nameof(Droping),2,1);
    }

    protected virtual void Droping()
    {
        this.dropCount++;
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;

        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos,dropRot);
        ItemDropCount itemDropCount;
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            itemDropCount = this.dropCountItems.Find(i => i.itemName == itemDropRate.itemSO.itemName);
            if(itemDropCount == null)
            {
                itemDropCount = new ItemDropCount();
                //itemS0 = itemprofileSO, quan li item
                itemDropCount.itemName = itemDropRate.itemSO.itemName;
                this.dropCountItems.Add(itemDropCount);
            }

            itemDropCount.count++;
            itemDropCount.rate =(float)Math.Round((float)itemDropCount.count / this.dropCount,2);
        }
    }
}
[Serializable]
public class ItemDropCount
{
    public string itemName;
    public int count;
    public float rate;
}

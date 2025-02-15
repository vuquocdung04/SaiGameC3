using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  class UIItemInventory : LoadAutoComponents
{
    [Header("UIItemInventory")]
    [SerializeField] protected TMP_Text itemName;
    public TMP_Text ItemName => itemName;
    [SerializeField] protected TMP_Text itemNumber;
    public TMP_Text ItemNumber => itemNumber;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
    }

    protected virtual void LoadItemName()
    {
        if (itemName != null) return;
        itemName = transform.Find("ItemName").GetComponent<TMP_Text>();
    }
    protected virtual void LoadItemNumber()
    {
        if (itemNumber != null) return;
        itemNumber = transform.Find("ItemNumber").GetComponent<TMP_Text>();
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemName.text = item.itemProfile.itemName;
        this.itemNumber.text = item.itemCount.ToString();
    }


}

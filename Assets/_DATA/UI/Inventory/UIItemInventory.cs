using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  class UIItemInventory : LoadAutoComponents
{
    [Header("UIItemInventory")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected TMP_Text itemName;
    public TMP_Text ItemName => itemName;
    [SerializeField] protected TMP_Text itemNumber;
    public TMP_Text ItemNumber => itemNumber;

    [SerializeField] protected Image itemImage;
    public Image ItemImage => itemImage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumber();
        this.LoadItemSprite();
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

    protected virtual void LoadItemSprite()
    {
        if (itemImage != null) return;
        itemImage = transform.Find("ItemImage").GetComponent<Image>();
    }

    public virtual void ShowItem(ItemInventory item)
    {
        // tao moi lien ket item ma khong qua reset
        this.itemInventory = item;

        this.itemName.text = item.itemProfile.itemName;
        this.itemNumber.text = item.itemCount.ToString();
        this.itemImage.sprite = this.itemInventory.itemProfile.sprite;
    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{
    static UIInventory instance;
    public static UIInventory Instance => instance;
    protected bool isOpen = false;

    [SerializeField] protected InventorySort inventorySort;
    public InventorySort InventorySort => inventorySort;
    protected override void Awake()
    {
        if (UIInventory.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        UIInventory.instance = this;
    }
    protected virtual void Start()
    {
        InvokeRepeating(nameof(ShowItems),1,1);
    }

    protected virtual void FixedUpdate()
    {
        //this.ShowItem();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.uIInventoryCtrl.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.uIInventoryCtrl.gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;
        //xoa het item

        this.ClearItem();
        List<ItemInventory> items = PlayerCtrl.Instance.ShipCtrl.Inventory.Items;
        UIInventorySpawner spawner = this.UIInventoryCtrl.UIInventorySpawner;

        foreach (ItemInventory item in items)
        {
            spawner.SpawnItem(item);
        }
        //show xong thi sap xep
        this.SortItems();

    }

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        int itemCount = this.UIInventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInventory currentUIItem, nextUIItem;
        ItemProfileSO currentProfile, nextProfile;

        string currentName, nextName;
        int currentCount, nextCount;

        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            currentItem = this.UIInventoryCtrl.Content.GetChild(i);
            nextItem = this.UIInventoryCtrl.Content.GetChild(i + 1);

            currentUIItem = currentItem.GetComponent<UIItemInventory>();
            nextUIItem = nextItem.GetComponent<UIItemInventory>();

            currentProfile = currentUIItem.ItemInventory.itemProfile;
            nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;

            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    currentName = currentProfile.itemName;
                    nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == 1;
                    break;
                case InventorySort.ByCount:
                    currentCount = currentUIItem.ItemInventory.itemCount;
                    nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount < nextCount;
                    break;
            }

            if (isSwap)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
        }

        if (isSorting) SortItems();


    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }

    protected virtual void ClearItem()
    {
        this.UIInventoryCtrl.UIInventorySpawner.ClearItem();
    }
    

}

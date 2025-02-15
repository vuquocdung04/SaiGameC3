using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventorySpawner : Spawner
{

    static UIInventorySpawner instance;
    public static UIInventorySpawner Instance => instance;

    public static string normalItem = "UIInventoryItem";

    [Header("UIInventorySpawner")]
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;
    protected override void Awake()
    {
        if (UIInventorySpawner.instance != null) Debug.LogError("Only 1 UIInventorySpawner allow to exist");
        UIInventorySpawner.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override void LoadHolders()
    {
        this.LoadUIInventoryCtrl();

        if (holders != null) return;
        this.holders = this.UIInventoryCtrl.Content;
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (uIInventoryCtrl != null) return;
        uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
    }

    public  virtual void ClearItem()
    {
        foreach (Transform item in this.holders)
        {
            this.Despawn(item);
        }
    }

    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.UIInventoryCtrl.UIInventorySpawner.Spawn(UIInventorySpawner.normalItem, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);

        UIItemInventory itemInventory = uiItem.GetComponent<UIItemInventory>();
        itemInventory.ShowItem(item);
        uiItem.gameObject.SetActive(true);
    }
}

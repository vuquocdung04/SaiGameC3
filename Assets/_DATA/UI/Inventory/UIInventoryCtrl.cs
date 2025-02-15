using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public  class UIInventoryCtrl : LoadAutoComponents
{
    [Header("UIInventoryCtrl")]
    [SerializeField] protected Transform content;
    public Transform Content => content;

    [SerializeField] protected UIInventorySpawner uIInventorySpawner;
    public UIInventorySpawner UIInventorySpawner => uIInventorySpawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIInventorySpawner();  
    }

    protected virtual void LoadContent()
    {
        if (content != null) return;
        content = transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
    protected virtual void LoadUIInventorySpawner()
    {
        if (uIInventorySpawner != null) return;
        uIInventorySpawner = transform.GetComponentInChildren<UIInventorySpawner>();
    }
}

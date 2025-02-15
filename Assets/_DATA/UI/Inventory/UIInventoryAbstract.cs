using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UIInventoryAbstract : LoadAutoComponents
{
    [Header("UIInventoryAbstract")]
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }

    protected virtual void LoadUIInventoryCtrl()
    {
        if (uIInventoryCtrl != null) return;
        uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
    }
}

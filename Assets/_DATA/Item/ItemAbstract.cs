using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : LoadAutoComponents
{
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemCtrl();
    }

    protected virtual void LoadItemCtrl()
    {
        if (itemCtrl != null) return;
        itemCtrl = GetComponentInParent<ItemCtrl>();
    }
}

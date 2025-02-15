using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHotKeyAbstract : LoadAutoComponents
{
    [SerializeField] protected UIHotKeyCtrl uIHotKeyCtrl;
    public UIHotKeyCtrl UIHotKeyCtrl => uIHotKeyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKeyCtrl();
    }

    protected virtual void LoadUIHotKeyCtrl()
    {
        if (uIHotKeyCtrl != null) return;
        uIHotKeyCtrl = GetComponentInParent<UIHotKeyCtrl>();
    }

}

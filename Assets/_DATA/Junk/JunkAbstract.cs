using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : LoadAutoComponents
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl => junkCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = GetComponentInParent<JunkCtrl>();
    }
}

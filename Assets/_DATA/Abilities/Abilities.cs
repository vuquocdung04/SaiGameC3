using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : LoadAutoComponents
{
    [Header("Abilities")]
    [SerializeField] protected AbilitiObjectCtrl abilitiObjectCtrl;
    public AbilitiObjectCtrl AbilitiObjectCtrl => abilitiObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilitiObjectCtrl();
    }

    protected virtual void LoadAbilitiObjectCtrl()
    {
        if (this.abilitiObjectCtrl != null) return;
        this.abilitiObjectCtrl = GetComponentInParent<AbilitiObjectCtrl>();
    }
}

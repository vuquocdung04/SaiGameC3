using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAbstract : LoadAutoComponents
{
    [Header("ShipAbstract")]
    [SerializeField] protected ShipCtrl shipCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        if (shipCtrl != null) return;
        shipCtrl = GetComponentInParent<ShipCtrl>();
    }
}

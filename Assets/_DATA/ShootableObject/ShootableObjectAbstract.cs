using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectAbstract : LoadAutoComponents
{
    [Header("ShootableObjectAbstract")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl => shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (shootableObjectCtrl != null) return;
        shootableObjectCtrl = GetComponentInParent<ShootableObjectCtrl>();
    }

}

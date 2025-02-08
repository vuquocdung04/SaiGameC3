using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAbstract : LoadAutoComponents
{

    [Header("==> BulletAbstract <==")]
    [SerializeField] protected BulletCtrl bulletCtrl;

    public BulletCtrl BulletCtrl => bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = GetComponentInParent<BulletCtrl>();
    }
}

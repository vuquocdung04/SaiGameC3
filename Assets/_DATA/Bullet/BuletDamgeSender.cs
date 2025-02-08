using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletDamgeSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = GetComponentInParent<BulletCtrl>();
    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        bulletCtrl.BulletDespawn.DespawnObj();
    }
}

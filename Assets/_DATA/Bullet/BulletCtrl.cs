using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : LoadAutoComponents
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
    }

    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;
        damageSender = GetComponentInChildren<DamageSender>();
    }

    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = GetComponentInChildren<BulletDespawn>();
    }
}

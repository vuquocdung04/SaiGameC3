using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : LoadAutoComponents
{
    [SerializeField] protected DamageSender damageSender;
    public DamageSender DamageSender => damageSender;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
    }

    protected virtual void LoadDamageSender()
    {
        if (damageSender != null) return;
        damageSender = GetComponentInChildren<DamageSender>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{

    [Header("==> Junk <==")]
    [SerializeField] protected JunkCtrl junkCtrl;

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

    protected override void OnDead()
    {
        this.junkCtrl.JunkDespawn.DespawnObj();
    }

    public override void ReBorn()
    {
        this.hpMax = this.junkCtrl.JunkSO.hpMax;
        base.ReBorn();
    }
}

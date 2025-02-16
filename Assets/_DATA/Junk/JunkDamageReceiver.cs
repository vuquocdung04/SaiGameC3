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
        this.OnDeadFX();
        this.DropOnDead();
        this.junkCtrl.JunkDespawn.DespawnObj();

    }
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,transform.position,Quaternion.identity);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual void DropOnDead()
    {
        Vector3 pos = this.transform.position;
        Quaternion rot = this.transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, pos,rot);

    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }

    public override void ReBorn()
    {
        this.hpMax = this.junkCtrl.ShootableObject.hpMax;
        base.ReBorn();
    }
}

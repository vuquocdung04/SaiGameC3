using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamagerReceiver : DamageReceiver
{

    [Header("==> ShootableObjectDamagerReceiver <==")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (shootableObjectCtrl != null) return;
        shootableObjectCtrl = GetComponentInParent<ShootableObjectCtrl>();
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.DropOnDead();
        this.shootableObjectCtrl.Despawn.DespawnObj();

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
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObject.dropList, pos,rot);

    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smoke1;
    }

    public override void ReBorn()
    {
        this.hpMax = this.shootableObjectCtrl.ShootableObject.hpMax;
        base.ReBorn();
    }
}

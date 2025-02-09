using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DamageSender : LoadAutoComponents
{
    [SerializeField] protected float damage;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.damage = 1f;
    }
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();

        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        
        this.CreateFXImpact();
    }

    protected virtual void CreateFXImpact()
    {
        string fxName = this.GetImpactFxName();
        Quaternion rot = Quaternion.Euler(0, 0, -90);
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, this.transform.position, transform.rotation * rot);
        fxImpact.gameObject.SetActive(true);
    }

    protected string GetImpactFxName()
    {
        return FXSpawner.impact1;
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }

    protected virtual void DestroyObj()
    {
        Destroy(transform.parent.gameObject);
        Debug.LogError("des");
    }
}

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

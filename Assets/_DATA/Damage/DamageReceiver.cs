using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : LoadAutoComponents
{
    [SerializeField] protected float hp;
    [SerializeField] protected float hpMax;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.hp = 1f;
        this.hpMax = 10f;
    }


    protected virtual void Start()
    {
        this.ReBorn();
    }

    public virtual void ReBorn()
    {
        this.hp = this.hpMax;
    }

    public virtual void Add(float add)
    {
        this.hp += add;
        if (this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(float deduct)
    {
        this.hp -= deduct;
        if (hp < 0) this.hp = 0;
    }

    protected virtual bool isDead()
    {
        return this.hp <= 0; // return true neu hp< 0
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class DamageReceiver : LoadAutoComponents
{
    [SerializeField] protected float hp;
    public float Hp => hp;
    [SerializeField] protected float hpMax;
    public float HpMax => hpMax;
    [SerializeField] protected bool isDead;

    [SerializeField] protected CircleCollider2D circleCollider;
    protected override void ResetValue()
    {
        base.ResetValue();
        this.hp = 1f;
        this.hpMax = 10f;
        this.ReBorn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (circleCollider != null) return;
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = 0.25f;
    }

    protected override void OnEnable()
    {
        this.ReBorn();
    }

    public virtual void ReBorn()
    {
        this.hp = this.hpMax;
        this.isDead = false;
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
        CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0; // return true neu hp< 0
    }

    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}

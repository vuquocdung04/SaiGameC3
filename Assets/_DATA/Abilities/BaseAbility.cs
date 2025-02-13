using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : LoadAutoComponents
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities => abilities;
    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isRead = false;


    protected virtual void FixedUpdate()
    {
        this.Timing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (abilities != null) return;
        abilities = GetComponentInParent<Abilities>();
    }

    protected virtual void Timing()
    {
        if (this.isRead) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isRead = true;

    }

    public virtual void Active()
    {
        this.isRead = false;
        this.timer = 0;
    }
}

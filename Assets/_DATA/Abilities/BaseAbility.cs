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
    [SerializeField] protected bool isReady = false;

    protected virtual void Update()
    {
        //for overide
    }
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
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;

    }

    public virtual void Active()
    {
        this.isReady = false;
        this.timer = 0;
    }
}

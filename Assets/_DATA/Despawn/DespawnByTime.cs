using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float delay;
    [SerializeField] protected float timer;

    protected override void OnEnable()
    {
        this.ResetTimer();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 2f;
        this.timer = 0f;
    }

    protected virtual void ResetTimer()
    {
        this.timer = 0;
    }

    // TODO  finish

    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        return (this.timer > this.delay);
    }

}

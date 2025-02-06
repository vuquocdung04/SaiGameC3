using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit;
    [SerializeField] protected float distance;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 70f;
        this.distance = 0f;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
    }
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}

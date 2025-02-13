using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    protected override void OnEnable()
    {
        this.distance = 0f;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 50f;
    }

    public override void DespawnObj()
    {
        JunkSpawner.Instance.Despawn(this.transform.parent);
    }


}

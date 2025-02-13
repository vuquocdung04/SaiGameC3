using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : DespawnByDistance
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
        EnemySpawner.Instance.Despawn(this.transform.parent);
    }


}

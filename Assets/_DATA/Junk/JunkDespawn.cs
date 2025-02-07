using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 20f;
    }

    protected override void DespawnObj()
    {
        JunkSpawner.Instance.Despawn(this.transform.parent);
    }


}

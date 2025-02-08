using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDespawn : DespawnByTime
{
    public override void DespawnObj()
    {
        FXSpawner.Instance.Despawn(this.transform.parent);
    }
}

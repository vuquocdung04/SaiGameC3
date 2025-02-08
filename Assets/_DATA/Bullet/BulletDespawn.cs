using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    public override void DespawnObj()
    {
        BulletSpawner.Instance.Despawn(this.transform.parent);
    }
}

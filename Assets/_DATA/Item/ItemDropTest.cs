using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : LoadAutoComponents
{
    public JunkCtrl junkCtrl;

    protected virtual void Start()
    {
        InvokeRepeating(nameof(Droping),2,1);
    }

    protected virtual void Droping()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;

        ItemDropSpawner.Instance.Drop(this.junkCtrl.ShootableObject.dropList, dropPos,dropRot);
    }
}

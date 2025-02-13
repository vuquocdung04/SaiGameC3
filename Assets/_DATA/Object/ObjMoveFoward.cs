using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveFoward : ObjMovement
{
    [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        this.GetMousePos();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMoveTarget();
    }
    protected virtual void LoadMoveTarget()
    {
        if (target != null) return;
        target = transform.Find("MoveTarget");
    }
    protected virtual void GetMousePos()
    {
        targetPos = target.position;
        this.targetPos.z = 0;
    }
}

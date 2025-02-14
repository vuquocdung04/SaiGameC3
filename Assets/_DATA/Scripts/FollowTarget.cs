using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : LoadAutoComponents
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float speed;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
    }

    protected virtual void FixedUpdate()
    {
        this.Following();
    }

    protected virtual void Following()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position,speed * Time.fixedDeltaTime);
    }

    // ham set target neu khong co lien ket loadcomponent

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}

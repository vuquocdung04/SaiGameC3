using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : LoadAutoComponents
{
    [Space(10)]
    [Header("ShipMovement")]
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;

    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
        this.Moving();
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPos - this.transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        this.transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, targetPos);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(this.transform.parent.position, targetPos, this.speed);
        this.transform.parent.position = newPos;
    }
}

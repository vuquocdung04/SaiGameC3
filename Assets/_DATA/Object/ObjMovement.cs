using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : LoadAutoComponents
{
    [Space(10)]
    [Header("ShipMovement")]
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 1f;

    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, targetPos);
        if (this.distance < this.minDistance) return;

        Vector3 newPos = Vector3.Lerp(this.transform.parent.position, targetPos, this.speed);
        this.transform.parent.position = newPos;
    }
}

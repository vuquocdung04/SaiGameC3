using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickupable : LoadAutoComponents
{
    [SerializeField] protected CircleCollider2D _circleCollider2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
    }

    protected virtual void LoadCollider2D()
    {
        if (_circleCollider2D != null) return;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        _circleCollider2D.radius = 0.05f;
    }
}

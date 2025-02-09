using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ItemPickupable : ItemAbstract
{
    [SerializeField] protected CircleCollider2D _circleCollider2D;

    public static ItemCode String2ItemCode(string itemName)
    {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }

    public virtual void OnMouseDown()
    {
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }


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

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }

    // pool item
    public virtual void Picked()
    {
        this.itemCtrl.ItemDespawn.DespawnObj();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class ItemLooter : InventoryAbstract
{
    [Space(10)]
    [Header("ItemLooter")]
    [SerializeField] protected Collider2D _collider2D;
    [SerializeField] protected Rigidbody2D _rigidbody2D;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider2D();
        this.LoadRigidbody2D();
    }

    protected virtual void LoadCollider2D()
    {
        if(_collider2D != null) return;
        _collider2D = GetComponent<Collider2D>();
        _collider2D.isTrigger = true;
    }
    protected virtual void LoadRigidbody2D()
    {
        if(_rigidbody2D != null) return ;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.gravityScale = 0f;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ItemPickupable itemPickupable = collision.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        // neu xay ra va cham thi => dua itemPickup vao pool
        if (this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}

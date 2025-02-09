using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : LoadAutoComponents
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    [SerializeField] protected ShipMovement shipMovement;
    public ShipMovement ShipMovement => shipMovement;

    [SerializeField] protected ShipShooting shipShooting;
    public ShipShooting ShipShooting => shipShooting;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
        this.LoadShipMovement();
        this.LoadShipShooting();
    }

    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = GetComponentInChildren<Inventory>();
    }

    protected virtual void LoadShipMovement()
    {
        if (shipMovement != null) return;
        shipMovement = GetComponentInChildren<ShipMovement>();
    }

    protected virtual void LoadShipShooting()
    {
        if(shipShooting != null) return;
        shipShooting = GetComponentInChildren<ShipShooting>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : LoadAutoComponents
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory => inventory;

    [SerializeField] protected ObjMovement shipMovement;
    public ObjMovement ShipMovement => shipMovement;

    [SerializeField] protected ObjShooting shipShooting;
    public ObjShooting ShipShooting => shipShooting;


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
        shipMovement = GetComponentInChildren<ObjMovement>();
    }

    protected virtual void LoadShipShooting()
    {
        if(shipShooting != null) return;
        shipShooting = GetComponentInChildren<ObjShooting>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl ShipCtrl => shipCtrl;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadShipCtrl();
        this.LoadPlayerPickup();
    }

    protected virtual void LoadShipCtrl()
    {
        //ToDO
        if (shipCtrl != null) return;
    }

    protected virtual void LoadPlayerPickup()
    {
        if (playerPickup != null) return;
        playerPickup = GetComponentInChildren<PlayerPickup>();
    }
}

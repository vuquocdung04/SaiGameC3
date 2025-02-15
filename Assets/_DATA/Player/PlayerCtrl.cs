using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : Singleton<PlayerCtrl>
{
    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl ShipCtrl => shipCtrl;

    [SerializeField] protected PlayerPickup playerPickup;
    public PlayerPickup PlayerPickup => playerPickup;

    [SerializeField] protected PlayerAbility playerAbility;
    public PlayerAbility PlayerAbility => playerAbility;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        //this.LoadShipCtrl();
        this.LoadPlayerPickup();
        this.LoadPlayerAbility();
    }

    protected virtual void LoadPlayerAbility()
    {
        if (playerAbility != null) return;
        playerAbility = GetComponentInChildren<PlayerAbility>();
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

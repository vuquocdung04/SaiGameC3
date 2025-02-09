using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : LoadAutoComponents
{

    [Header("Player Abstract")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl => playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
}

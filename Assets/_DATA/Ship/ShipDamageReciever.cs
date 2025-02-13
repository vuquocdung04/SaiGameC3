using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReciever : DamageReceiver
{
    protected override void OnDead()
    {
        Debug.LogError("player dead");
    }
}

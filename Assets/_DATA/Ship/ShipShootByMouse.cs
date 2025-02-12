using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ShipShooting
{
    protected override bool IsShooting()
    {
        this.isShootting = InputManager.Instance.onFiring;
        return isShootting;
    }


}

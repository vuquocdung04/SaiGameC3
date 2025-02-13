using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ObjMovement
{
    protected override void FixedUpdate()
    {
        this.GetMousePos();
        base.FixedUpdate();
    }

    protected virtual void GetMousePos()
    {
        targetPos = InputManager.Instance.mouseWorldPos;
        this.targetPos.z = 0;
    }

}

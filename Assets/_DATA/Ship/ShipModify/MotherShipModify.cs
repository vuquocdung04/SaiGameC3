using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipModify : ObjModifyAbstract
{
    [Header("Mother ship")]
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float rotSpeed = 0.01f;

    protected virtual void Start()
    {
        this.ShipModify();
    }

    protected virtual void ShipModify()
    {
        // set para speed
        this.shootableObjectCtrl.ObjMovement.SetSpeed(this.speed);
        //set para rotation
        this.shootableObjectCtrl.ObjLookAtTarget.SetRotSpeed(this.rotSpeed);
    }
}

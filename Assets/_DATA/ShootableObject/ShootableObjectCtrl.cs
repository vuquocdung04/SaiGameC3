using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : LoadAutoComponents
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected ShootableObject shootableObject;
    public ShootableObject ShootableObject => shootableObject;

    [SerializeField] protected ObjShooting shooting;
    public ObjShooting ObjShooting => shooting;

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement => objMovement;

    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget => objLookAtTarget;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjShooting();
        this.LoadObjMovement();
        this.LoadObjLookAtTarget();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = GetComponentInChildren<Despawn>();
    }

    protected virtual void LoadSO()
    {
        if (shootableObject != null) return;
        string resPath = "ShootableObject/" + this.GetObjectTypeName()+"/" + transform.name; // transform.name =>> load dung scripttable obj giong ten obj trong hirachie
        shootableObject = Resources.Load<ShootableObject>(resPath);
    }

    protected virtual void LoadObjShooting()
    {
        if (shooting != null) return;
        shooting = GetComponentInChildren<ObjShooting>();
    }

    protected virtual void LoadObjMovement()
    {
        if (objMovement != null) return;
        objMovement = GetComponentInChildren<ObjMovement>();
    }
    protected virtual void LoadObjLookAtTarget()
    {
        if (objLookAtTarget != null) return;
        objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
    }
    protected abstract string GetObjectTypeName();
}

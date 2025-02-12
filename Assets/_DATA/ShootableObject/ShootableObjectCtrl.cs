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
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
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

    protected abstract string GetObjectTypeName();
}

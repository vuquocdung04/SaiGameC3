using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : LoadAutoComponents
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn;

    [SerializeField] protected ShootableObject  shootableObject;
    public ShootableObject ShootableObject => shootableObject;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
        this.LoadJunkSO();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        this.model = transform.Find("Model");
    }

    protected virtual void LoadJunkDespawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = GetComponentInChildren<JunkDespawn>();
    }

    protected virtual void LoadJunkSO()
    {
        if (shootableObject != null) return;
        string resPath = "ShootableObject/Junk/" + transform.name; // transform.name =>> load dung scripttable obj giong ten obj trong hirachie
        shootableObject = Resources.Load<ShootableObject>(resPath);
    }
}

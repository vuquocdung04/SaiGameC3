using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : LoadAutoComponents
{
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn => junkDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadJunkDespawn();
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
}

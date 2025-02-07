using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : LoadAutoComponents
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;

    [SerializeField] protected JunkRandom junkRandom;
    public JunkRandom JunkRandom => junkRandom;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkRandom();
    }
    protected virtual void LoadJunkSpawner()
    {
        if (junkSpawner != null) return;
        junkSpawner = GetComponent<JunkSpawner>();
    }

    protected virtual void LoadJunkRandom()
    {
        if (junkRandom != null) return;
        junkRandom = GetComponent<JunkRandom>();
    }
}

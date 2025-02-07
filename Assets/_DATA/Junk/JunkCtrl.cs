using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : LoadAutoComponents
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;

    [SerializeField] protected JunkRandom junkRandom;
    public JunkRandom JunkRandom => junkRandom;

    [SerializeField] protected JunkSpawnPoints junkSpawnPoints;
    public JunkSpawnPoints JunkSpawnPoints => junkSpawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadJunkRandom();
        this.LoadJunkSpawnPoints();
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

    protected virtual void LoadJunkSpawnPoints()
    {
        if (junkSpawnPoints != null) return;
        junkSpawnPoints = Transform.FindObjectOfType<JunkSpawnPoints>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : LoadAutoComponents
{
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = GetComponent<Spawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>();
    }
}

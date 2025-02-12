using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : LoadAutoComponents
{
    [SerializeField] protected EnemySpawner spawner;
    public EnemySpawner Spawner => spawner;

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
        spawner = GetComponent<EnemySpawner>();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = Transform.FindObjectOfType<SpawnPoints>();
    }
}

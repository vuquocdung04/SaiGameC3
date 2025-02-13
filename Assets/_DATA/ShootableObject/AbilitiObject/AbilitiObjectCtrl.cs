using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiObjectCtrl : ShootableObjectCtrl
{
    [Header("Abiliti Object")]
    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = GetComponentInChildren<SpawnPoints>();
    }

    protected override string GetObjectTypeName()
    {
        throw new System.NotImplementedException();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : LoadAutoComponents
{
    [Header("Spawner Ramdom")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float ramdomDelay;
    [SerializeField] protected float ramdomTimer;
    [SerializeField] protected float ramdomLimit;
    private void FixedUpdate()
    {
        this.JunkSpawning();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.ramdomDelay = 0.5f;
        this.ramdomTimer = 0f;
        this.ramdomLimit = 20f;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnerCtrl();
    }


    protected virtual void LoadJunkSpawnerCtrl()
    {
        if (spawnerCtrl != null) return;
        spawnerCtrl = GetComponent<SpawnerCtrl>();
    }


    protected virtual void JunkSpawning()
    {
        if (this.RamdomReachLimit()) return;
        this.ramdomTimer += Time.fixedDeltaTime;
        if (this.ramdomTimer < this.ramdomDelay) return;
        this.ramdomTimer = 0;

        Transform ranPoint = this.spawnerCtrl.SpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.spawnerCtrl.Spawner.RandomPrefab();
        Transform obj = this.spawnerCtrl.Spawner.Spawn(prefab, pos,rot);

        obj.gameObject.SetActive(true);
    } 

    protected virtual bool RamdomReachLimit()
    {
        int currentJunk = this.spawnerCtrl.Spawner.SpawnedCount;
        return currentJunk >= this.ramdomLimit;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : LoadAutoComponents
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
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
        this.ramdomDelay = 1f;
        this.ramdomTimer = 0f;
        this.ramdomLimit = 9f;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnerCtrl();
    }


    protected virtual void LoadJunkSpawnerCtrl()
    {
        if (junkSpawnerCtrl != null) return;
        junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
    }


    protected virtual void JunkSpawning()
    {
        if (this.RamdomReachLimit()) return;
        this.ramdomTimer += Time.fixedDeltaTime;
        if (this.ramdomTimer < this.ramdomDelay) return;
        this.ramdomTimer = 0;

        Transform ranPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRandom();
        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(prefab, pos,rot);

        obj.gameObject.SetActive(true);
    } 

    protected virtual bool RamdomReachLimit()
    {
        int currentJunk = this.junkSpawnerCtrl.JunkSpawner.SpawnedCount;
        return currentJunk >= this.ramdomLimit;
    }
}

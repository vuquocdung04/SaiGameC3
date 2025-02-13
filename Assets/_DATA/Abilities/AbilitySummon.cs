using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummon : BaseAbility
{
    [Header("Ability Summon")]
    [SerializeField] protected Spawner spawner;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Summoning();
    }

    protected virtual void Summoning()
    {
        if (!isRead) return;
        this.Summon();
    }
    //spawn enemy
    protected virtual Transform Summon()
    {
        Transform spawnPos = this.abilities.AbilitiObjectCtrl.SpawnPoints.GetRandom();


        Transform minionPrefab = this.spawner.RandomPrefab();
        Transform minion = this.spawner.Spawn(minionPrefab, spawnPos.position, spawnPos.rotation);

        minion.gameObject.SetActive(true);
        this.Active();

        return minion;

    }
}

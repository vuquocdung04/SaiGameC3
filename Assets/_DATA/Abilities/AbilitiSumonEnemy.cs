using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiSumonEnemy : AbilitySummon
{
    [Header("Sumon Enemy")]
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int  minionLimit = 2;

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ClearDeathMinions();

    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");

        spawner = enemySpawner.GetComponent<EnemySpawner>();
    }
    protected override void Summoning()
    {
        if (this.minions.Count >= this.minionLimit) return;
        base.Summoning();
        
    }


    protected override Transform Summon()
    {


        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilitiObjectCtrl.transform;
        this.minions.Add(minion);
        return minion;

    }

    protected virtual void ClearDeathMinions()
    {
        foreach(Transform minion in this.minions)
        {
            if(minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
}

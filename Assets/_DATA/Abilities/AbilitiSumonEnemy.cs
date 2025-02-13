using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiSumonEnemy : AbilitySummon
{
    //[Header("Sumon Enemy")]
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
}

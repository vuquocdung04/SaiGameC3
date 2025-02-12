using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected override void Awake()
    {
        if (EnemySpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        EnemySpawner.instance = this;
    }
}

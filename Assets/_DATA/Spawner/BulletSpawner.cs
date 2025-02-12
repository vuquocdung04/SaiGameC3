using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    public static string bulletOne = "Bullet_1";

    static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    protected override void Awake()
    {
        if (BulletSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        BulletSpawner.instance = this;
    }

}

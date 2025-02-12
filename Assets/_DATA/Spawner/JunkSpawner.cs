using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    static JunkSpawner instance;
    public static JunkSpawner Instance => instance;

    protected override void Awake()
    {
        if (JunkSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        JunkSpawner.instance = this;
    }
}

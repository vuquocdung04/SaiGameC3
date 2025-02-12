using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    public static string smoke1 = "Smoke_1a";
    public static string impact1 = "Impact_1";

    static FXSpawner instance;
    public static FXSpawner Instance => instance;

    protected override void Awake()
    {
        if (FXSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        FXSpawner.instance = this;
    }
}

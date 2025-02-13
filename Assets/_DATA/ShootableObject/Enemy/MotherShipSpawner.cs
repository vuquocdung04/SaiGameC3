using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : Spawner
{
    static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;

    protected override void Awake()
    {
        if (MotherShipSpawner.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        MotherShipSpawner.instance = this;
    }
}

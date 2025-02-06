using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : Singleton<Spawner>
{
    [SerializeField] protected List<Transform> prefabs;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullets();
    }

    protected virtual void LoadBullets()
    {
        if (this.prefabs.Count > 0) return;

        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            prefabs.Add(prefab);
        }
        HidePrefabs();
    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public Transform Spawn(string prefabName,Vector2 spawnPos, Quaternion rotation)
    {

        Transform prefab = GetPrefabName(prefabName);
        if (prefab == null) return null;

        Transform newBullet = Instantiate(prefab, spawnPos,rotation);

        return newBullet;

    }

    protected virtual Transform GetPrefabName(string name)
    {
        foreach (Transform prefab in prefabs)
        {
            if(prefab.name == name) return prefab;
        }
        return null;
    }
}

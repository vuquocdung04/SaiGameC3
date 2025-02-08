using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : Singleton<T> where T :LoadAutoComponents
{
    [SerializeField] protected Transform holders;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount => spawnedCount;

    [Space(10)]
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullets();
        this.LoadHolders();
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

    protected virtual void LoadHolders()
    {
        if (this.holders != null) return;
        this.holders = transform.Find("Holders");
    }


    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in prefabs)
        {
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName,Vector2 spawnPos, Quaternion rotation)
    {

        Transform prefab = GetPrefabName(prefabName);
        if (prefab == null) return null;

        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos,rotation);

        newPrefab.parent = this.holders;
        this.spawnedCount++;
        return newPrefab;

    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        foreach (Transform poolObj in this.poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : LoadAutoComponents
{
    [SerializeField] protected List<Transform> prefabs;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullets();
    }

    protected virtual void LoadBullets()
    {
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
}

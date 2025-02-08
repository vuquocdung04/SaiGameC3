using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : LoadAutoComponents
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    private void Start()
    {
        InvokeRepeating(nameof(JunkSpawning),1,1);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawnerCtrl();
    }


    protected virtual void LoadJunkSpawnerCtrl()
    {
        if (junkSpawnerCtrl != null) return;
        junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
    }


    protected virtual void JunkSpawning()
    {
        Transform ranPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRandom();

        Vector3 pos = ranPoint.position;
        Quaternion rot = transform.rotation;

        Transform obj = this.junkSpawnerCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos,rot);

        obj.gameObject.SetActive(true);
    } 

}

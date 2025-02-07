using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : LoadAutoComponents
{
    [SerializeField] protected JunkCtrl junkCtrl;

    private void Start()
    {
        InvokeRepeating(nameof(JunkSpawning),1,1);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }


    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = GetComponent<JunkCtrl>();
    }


    protected virtual void JunkSpawning()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        Transform obj = this.junkCtrl.JunkSpawner.Spawn(JunkSpawner.meteoriteOne, pos,rot);

        obj.gameObject.SetActive(true);

    } 
}

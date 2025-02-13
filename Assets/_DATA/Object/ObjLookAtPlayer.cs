using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer : ObjLookAtTarget
{
    [SerializeField] protected GameObject player;

    protected override void FixedUpdate()
    {
        this.GetMousePos();
        base.FixedUpdate();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    protected virtual void GetMousePos()
    {
        if (this.player == null) return;
        targetPos = this.player.transform.position;
        this.targetPos.z = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearBigger : ObjAppearing
{
    [Header("ObjAppearBigger")]
    [SerializeField] protected float speedScale = 0.01f;
    [SerializeField] protected float currentScale = 0f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.InitScale();
    }

    protected virtual void InitScale()
    {
        transform.parent.localScale = Vector3.zero;
        this.currentScale = this.startScale;
    }
    protected override void Appearing()
    {
        this.currentScale += this.speedScale;
        transform.parent.localScale = new Vector3(this.currentScale,this.currentScale,this.currentScale);
        if (currentScale >= maxScale) this.Appear();
    }

    public override void Appear()
    {
        base.Appear();
        transform.parent.localScale = new Vector3(this.maxScale,this.maxScale,this.maxScale);
    }
}

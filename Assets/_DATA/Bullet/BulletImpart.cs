using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class BulletImpart : BulletAbstract
{

    [Header("==> BulletImpart <==")]
    [SerializeField] protected Rigidbody2D _rb;
    [SerializeField] protected CircleCollider2D _circleCollider2D;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (_rb != null) return;
        _rb = GetComponent<Rigidbody2D>();
        _rb.isKinematic = true;
    }
 
    protected virtual void LoadCircleCollider2D()
    {
        if (_circleCollider2D != null) return;
        _circleCollider2D = GetComponent<CircleCollider2D>();
        _circleCollider2D.isTrigger = true;
        _circleCollider2D.radius = 0.03f;
    }


    protected virtual void CreateFXImpact(Collider2D collision)
    {
        string fxName = this.GetImpactFxName();
        Quaternion rot = Quaternion.Euler(0,0,-90);
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, this.transform.position,transform.rotation * rot);
        fxImpact.gameObject.SetActive(true);
    }

    protected string GetImpactFxName()
    {
        return FXSpawner.impact1;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        this.bulletCtrl.DamageSender.Send(collision.transform);
        this.CreateFXImpact(collision);
    }


}

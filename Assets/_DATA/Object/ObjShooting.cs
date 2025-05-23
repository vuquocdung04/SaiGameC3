using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : LoadAutoComponents
{
    [Space(10)]
    [Header("ShipShooting")]
    [SerializeField] protected bool isShootting;

    [SerializeField] protected float shootDelay = 0.4f;
    [SerializeField] protected float shootTimer = 0f;
    private void Update()
    {
        this.IsShooting();
        //this.Shooting();
    }

    private void FixedUpdate()
    {
        Shooting();
    }

    protected virtual void Shooting()
    {
        if (!isShootting) return;

        shootTimer += Time.fixedDeltaTime;
        if (this.shootDelay > this.shootTimer) return;
        this.shootTimer = 0;
        Quaternion rotation = this.transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne,transform.position, rotation);
        if (newBullet == null) return;

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);

        newBullet.gameObject.SetActive(true);
    }

    protected abstract bool IsShooting();
}

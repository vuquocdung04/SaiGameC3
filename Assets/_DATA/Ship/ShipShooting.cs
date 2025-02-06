using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShootting;

    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;

    [SerializeField] protected Transform bullet;
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


        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        this.isShootting = InputManager.Instance.onFiring == 1;
        return isShootting;
    }
}

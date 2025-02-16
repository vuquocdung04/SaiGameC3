using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HP Bar de show 
public class HPBar : LoadAutoComponents
{
    [Header("HPBar")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected SliderHP sliderHp;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;



    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }

    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = GetComponentInParent<Spawner>();
    }
    protected virtual void LoadFollowTarget()
    {
        if (followTarget != null) return;
        followTarget = GetComponent<FollowTarget>();
    }
    protected virtual void LoadSliderHP()
    {
        if (sliderHp != null) return;
        sliderHp = GetComponentInChildren<SliderHP>();
    }

    protected virtual void HPShowing()
    {
        if (shootableObjectCtrl == null) return;

        bool isDead = this.shootableObjectCtrl.DamageReceiver.IsDead();
        if (isDead)
        {
            this.spawner.Despawn(transform);
            return;
        }

        float hp = this.shootableObjectCtrl.DamageReceiver.Hp;
        float maxHp = this.shootableObjectCtrl.DamageReceiver.HpMax;

        this.sliderHp.SetCurrentHp(hp);
        this.sliderHp.SetMaxHp(maxHp);

    }

    // vi ShotableObjCtrl khong loadcomponent duoc thi phai tao ham nay
    public virtual void SetObjShootCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }

    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }
}

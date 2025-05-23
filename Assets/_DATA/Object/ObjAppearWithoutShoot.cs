using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbstract, ObjAppearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjAppearing objAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjAppearing();
    }

    protected virtual void LoadObjAppearing()
    {
        if (objAppearing != null) return;
        objAppearing = GetComponent<ObjAppearing>();
    }

    // observers
    protected virtual void RegisterAppearEvent()
    {
        this.objAppearing.ObserverAdd(this);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(false);
    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.ObjShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.ObjLookAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtrl.Spawner.Hold(transform.parent);
    }
}

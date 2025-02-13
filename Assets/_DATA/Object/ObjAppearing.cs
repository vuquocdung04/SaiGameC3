using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppearing : LoadAutoComponents
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool isAppearing = false;
    public bool IsAppearing => isAppearing;
    [SerializeField] protected bool appeared = false;
    public bool Appeared => appeared;

    [SerializeField] protected List<ObjAppearObserver> observers = new List<ObjAppearObserver>();

    protected virtual void Start()
    {
        this.OnAppearStart();
    }
    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        this.appeared = true;
        this.isAppearing = false;
        this.OnAppearFinish();
    }

    public virtual void ObserverAdd(ObjAppearObserver observer)
    {
        this.observers.Add(observer);
    }

    protected virtual void OnAppearStart()
    {
        foreach(ObjAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach(ObjAppearObserver observer in observers)
        {
            observer.OnAppearFinish();
        }
    }

}

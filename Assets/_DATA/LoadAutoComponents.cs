using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAutoComponents : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponents();
    }

    private void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }
    protected virtual void LoadComponents()
    {

    }

    protected virtual void ResetValue()
    {

    }
    protected virtual void OnEnable()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : LoadAutoComponents
{
    static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance => instance;

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 BulletSpawner allow to exist");
        UIHotKeyCtrl.instance = this;
    }
}

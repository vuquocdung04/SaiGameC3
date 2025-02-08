using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : Singleton<GameCtrl>
{
    [SerializeField] protected Camera cam;
    public Camera Cam => cam;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCameraObj();
    }

    protected virtual void LoadCameraObj()
    {
        if (cam != null) return;
        cam = GameCtrl.FindObjectOfType<Camera>();
    }
}

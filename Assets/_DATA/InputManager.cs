using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    [SerializeField] public Vector3 mouseWorldPos;
    [SerializeField] public bool onFiring;
    private void Update()
    {
        this.GetMouseDown();
    }

    private void FixedUpdate()
    {
        GetMousePos();
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetMouseButton(0);
    }
    protected virtual void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    [SerializeField] public Vector3 mouseWorldPos;
    [SerializeField] public float onFiring;
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
        this.onFiring = Input.GetAxis("Fire1");
    }
    protected virtual void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

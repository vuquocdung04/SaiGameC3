using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    [SerializeField] public Vector3 mouseWorldPos;
    [SerializeField] public bool onFiring;

    [SerializeField] protected Vector4 direction;
    public Vector4 Direction => direction;
    private void Update()
    {
        this.GetMouseDown();
        this.GetDirectionByKeyDown();
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

    protected virtual void GetDirectionByKeyDown()
    {
        // vector4 4 huong 
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        if (this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;

        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        if (this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        if (this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;

        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        if (this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;
    }
}

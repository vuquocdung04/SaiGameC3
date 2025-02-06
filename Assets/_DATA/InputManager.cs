using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{

    [SerializeField] public Vector3 mouseWorldPos;

    private void FixedUpdate()
    {
        GetMousePos();
    }
    protected virtual void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}

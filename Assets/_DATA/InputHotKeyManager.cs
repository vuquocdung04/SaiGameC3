using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHotKeyManager : Singleton<InputHotKeyManager>
{
    public bool Alpha1 = false;
    public bool Alpha2 = false;
    public bool Alpha3 = false;
    public bool Alpha4 = false;
    public bool Alpha5 = false;
    public bool Alpha6 = false;
    public bool Alpha7 = false;

    private void Update()
    {
        this.GetHotKeyPress();
    }

    protected virtual void GetHotKeyPress()
    {
        this.Alpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        this.Alpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        this.Alpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        this.Alpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        this.Alpha5 = Input.GetKeyDown(KeyCode.Alpha5);
        this.Alpha6 = Input.GetKeyDown(KeyCode.Alpha6);
        this.Alpha7 = Input.GetKeyDown(KeyCode.Alpha7);
    }
}

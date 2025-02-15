using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressAlpha : UIHotKeyAbstract
{
    private void Update()
    {
        CheckAlphaPress();
    }

    protected virtual void CheckAlphaPress()
    {
        if (InputHotKeyManager.Instance.Alpha1) this.PressAlpha(0);
        if (InputHotKeyManager.Instance.Alpha2) this.PressAlpha(1);
        if (InputHotKeyManager.Instance.Alpha3) this.PressAlpha(2);
        if (InputHotKeyManager.Instance.Alpha4) this.PressAlpha(3);
        if (InputHotKeyManager.Instance.Alpha5) this.PressAlpha(4);
        if (InputHotKeyManager.Instance.Alpha6) this.PressAlpha(5);
        if (InputHotKeyManager.Instance.Alpha7) this.PressAlpha(6);
    }

    protected virtual void PressAlpha(int alpha)
    {
        Debug.Log("Click: " + alpha);
        ItemSlot itemSlot = this.UIHotKeyCtrl.itemSlots[alpha];
        Pressable pressAble = itemSlot.GetComponentInChildren<Pressable>();
        if (pressAble == null) return;
        pressAble.Pressed();
    }
}

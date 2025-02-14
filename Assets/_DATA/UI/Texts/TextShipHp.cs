using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHp : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHpText();
    }

    protected virtual void UpdateShipHpText()
    {
        float hpMax = PlayerCtrl.Instance.ShipCtrl.DamageReceiver.HpMax;
        float currentHp = PlayerCtrl.Instance.ShipCtrl.DamageReceiver.Hp;
        this.text.SetText(currentHp + "/" + hpMax);
    }
}

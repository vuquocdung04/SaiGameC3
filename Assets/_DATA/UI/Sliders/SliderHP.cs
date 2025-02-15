using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
    [Header("SliderHp")]
    [SerializeField] protected float maxHp = 100;
    [SerializeField] protected float currentHP = 70;

    protected override void FixedUpdate()
    {
        this.HpShowing();
    }

    protected virtual void HpShowing()
    {
        float hpPercent = this.currentHP/ this.maxHp;
        //Debug.LogError(currentHP);
        this.slider.value = hpPercent;
    }

    protected override void OnChanged(float value)
    {
        Debug.Log("cHECK");
    }

    public virtual void SetMaxHp(float maxHP)
    {
        this.maxHp = maxHP;
    }

    public virtual void SetCurrentHp(float currentHP)
    {
        this.currentHP = currentHP;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
    [Header("SliderHp")]
    [SerializeField] protected float maxHp = 100f;
    [SerializeField] protected float currentHP = 70f;

    protected override void FixedUpdate()
    {
        this.HpShowing();
    }

    protected virtual void HpShowing()
    {
        float hpPercent = this.currentHP / this.maxHp;
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

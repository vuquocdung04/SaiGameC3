using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : LoadAutoComponents
{
    [Header("BaseSlider")]
    [SerializeField] protected Slider slider;

    private void Start()
    {
        this.AddOnClickEvent();
    }
    protected virtual void FixedUpdate()
    {
        //for override
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (slider != null) return;
        slider = GetComponent<Slider>();
    }

    protected virtual void AddOnClickEvent()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }

    protected abstract void OnChanged(float value);
}

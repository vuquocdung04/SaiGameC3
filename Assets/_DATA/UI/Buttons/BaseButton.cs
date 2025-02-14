using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : LoadAutoComponents
{
    [Header("Base Button")]
    [SerializeField] protected Button button;

    protected virtual void Start()
    {
        this.AddOnClickEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadButton();
    }

    protected virtual void LoadButton()
    {
        if (button != null) return;
        button = GetComponent<Button>();
    }

    protected virtual void AddOnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}

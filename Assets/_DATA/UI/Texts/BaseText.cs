using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseText : LoadAutoComponents
{
    [Header("BaseText")]
    [SerializeField] protected TMP_Text text;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadText();
    }

    protected virtual void LoadText()
    {
        if (text != null) return;
        text = GetComponent<TMP_Text>();
    }

}

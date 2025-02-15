using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerAbility : LoadAutoComponents
{
    public virtual void Active(AbilitiesCode abilitiesCode)
    {
        Debug.LogError("Skill: " + abilitiesCode.ToString());
    }
}

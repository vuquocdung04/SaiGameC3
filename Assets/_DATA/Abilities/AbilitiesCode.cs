using System.Diagnostics;
using System;
using UnityEngine;
public enum AbilitiesCode
{
    NoAbility = 0,
    Missle = 1,
    Laze = 2,
}

public class AbilitiesCodeParser
{
    public static AbilitiesCode FromString(string itemName)
    {
        try
        {
            return (AbilitiesCode)System.Enum.Parse(typeof(AbilitiesCode),itemName); // chuyen enum => string
        }
        catch(ArgumentException e)
        {
            UnityEngine.Debug.LogError(e.ToString());
            return AbilitiesCode.NoAbility;
        }
    }
}
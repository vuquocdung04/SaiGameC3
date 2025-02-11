using System.Diagnostics;
using System;
using UnityEngine;
public enum ItemCode
{
    NoItem = 0,
    IronOre = 1,
    GoldOre = 2,
    RubyOre = 3,
    Sword = 1000,
}

public class ItemCodeParser
{
    public static ItemCode FromString(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode),itemName); // chuyen enum => string
        }
        catch(ArgumentException e)
        {
            UnityEngine.Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
}
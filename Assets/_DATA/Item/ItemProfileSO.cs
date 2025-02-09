using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "SO/ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "name";
    public int defaultMaxStack = 7;

    public List<ItemRecipe> upgradeLevels;
}

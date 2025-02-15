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
    public Sprite sprite;
    public List<ItemRecipe> upgradeLevels;


    public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            Debug.Log(itemCode);
            return profile;
        }
        return null;

    }
}


using System;
using UnityEngine.Experimental.GlobalIllumination;

[Serializable]

// hieu la struct cung duoc
public class ItemInventory 
{

    public string itemID;
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            itemID = ItemInventory.RandomItemID(),
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            maxStack = this.upgradeLevel
        };
        return item;
    }
    public static string RandomItemID()
    {
        return RandomStringGenerator.Generator(27);
    }
}

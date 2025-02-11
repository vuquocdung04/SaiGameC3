
using System;

[Serializable]

// hieu la struct cung duoc
public class ItemInventory 
{
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;

    public virtual ItemInventory Clone()
    {
        ItemInventory item = new ItemInventory
        {
            itemProfile = this.itemProfile,
            itemCount = this.itemCount,
            maxStack = this.upgradeLevel
        };
        return item;
    }
}

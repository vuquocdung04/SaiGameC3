
using System;

[Serializable]

// hieu la struct cung duoc
public class ItemInventory 
{
    public ItemProfileSO itemProfile;
    public int itemCount = 0;
    public int maxStack = 7;
    public int upgradeLevel = 0;
}

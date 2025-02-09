using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Space(10)]
    [Header("ItemUpgrade")]
    [SerializeField] protected int maxLevel;


    private void Start()
    {
        Invoke(nameof(Test),2);
    }

    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }
    public virtual bool UpgradeItem(int itemIndex)
    {
        if(itemIndex >= this.inventory.Items.Count) return false;

        ItemInventory itemInventory = this.inventory.Items[itemIndex];

        if (itemInventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;

        if(!this.ItemUpgradeable(upgradeLevels)) return false;

        if (!this.HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;

        // kiem tra het roi thi moi tru
        this.DeductIngredients(upgradeLevels, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;

        Debug.LogError("UpgradeItemComplete");

        return true;


    }

    protected virtual bool ItemUpgradeable(List<ItemRecipe> upgradeLevels)
    {
        if (upgradeLevels.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        if(currentLevel > upgradeLevels.Count)
        {
            Debug.LogError("Item cant upgrade anymore, current " + currentLevel);
            return false;
        }

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];

        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.itemRecipeIngredients)
        {
            itemCode = ingredient.itemProfileSO.itemCode;
            itemCount = ingredient.itemCount;

            if(!this.inventory.ItemCheck(itemCode, itemCount)) return false;
        }
        return true;
    }

    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.itemRecipeIngredients)
        {
            itemCode = ingredient.itemProfileSO.itemCode;
            itemCount = ingredient.itemCount;

            this.inventory.DeductItem(itemCode, itemCount);
        }
    }


}

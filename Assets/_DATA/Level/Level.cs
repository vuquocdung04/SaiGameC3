using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : LoadAutoComponents
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 0;
    public int LevelCurrent => levelCurrent;
    [SerializeField] protected int levelMax = 99;

    public int LevelMax => levelMax;

    public virtual void LevelUp()
    {
        this.levelCurrent += 1;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel)
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }

    // check level khong qua duoc levelmax va duoi 0
    protected virtual void LimitLevel()
    {
        if(this.levelCurrent > this.levelMax) this.levelCurrent = this.levelMax;
        if(this.levelCurrent < 1) this.levelCurrent = 1;
    }
}

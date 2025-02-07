using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnPoints : LoadAutoComponents
{
    [SerializeField] protected List<Transform> points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoints();
    }

    protected virtual void LoadPoints()
    {
        if (points.Count > 0) return;
        foreach (Transform point in transform)
        {
            points.Add(point);
        }
    }

    public virtual Transform GetRandom()
    {
        int rand = Random.Range(0, this.points.Count);
        return points[rand];
    }
}

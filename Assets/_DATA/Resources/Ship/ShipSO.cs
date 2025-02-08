using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjs/Ship")]
public class ShipSO : ScriptableObject
{
    public string shipName = "Ship";
    public float hpMax;
}

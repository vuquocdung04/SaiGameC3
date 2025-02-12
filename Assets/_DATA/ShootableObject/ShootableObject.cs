using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObject : ScriptableObject
{
    public string objName = "ShootableObject";
    public ObjType objType;
    public float hpMax;
    public List<DropRate> dropList;
}

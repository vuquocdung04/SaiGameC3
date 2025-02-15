using UnityEngine;
using UnityEngine.UI;

public class PressableAbility : Pressable
{
    [SerializeField] protected AbilitiesCode abilitiesCode;
    public override void Pressed()
    {
        PlayerCtrl.Instance.PlayerAbility.Active(abilitiesCode);
    }
}

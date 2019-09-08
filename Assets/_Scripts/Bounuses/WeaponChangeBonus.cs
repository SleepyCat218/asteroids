using UnityEngine;

public class WeaponChangeBonus : BaseBonus
{
    [SerializeField] private Weapon _weapon;

    protected override void ApplyBonus(IBonusGetter bonusGetter)
    {
        bonusGetter.ChangeWeapon(_weapon);
    }
}

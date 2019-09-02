using UnityEngine;

public class WeaponChangeBonus : BaseBonus
{
    [SerializeField] private Weapon _weapon;

    protected override void ApplyBonus(PlayerController player)
    {
        player.ChangeWeapon(_weapon);
    }
}

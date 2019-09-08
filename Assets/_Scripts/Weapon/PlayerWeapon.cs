using UnityEngine;

public class PlayerWeapon : BaseWeapon
{
    public Weapon Weapon
    {
        get
        {
            return _weapon;
        }
        set
        {
            _weapon = value;
            LoadWeapon();
        }
    }

    protected override Quaternion GetProjectileRotation()
    {
        return transform.rotation;
    }
}

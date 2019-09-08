using UnityEngine;

public class PlayerBonusGetter : MonoBehaviour, IBonusGetter
{
    private PlayerBaseHealth _playerHealth;
    private PlayerWeapon _playerWeapon;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerBaseHealth>();
        _playerWeapon = GetComponent<PlayerWeapon>();
    }

    public void RestoreHealth(float hp)
    {
        _playerHealth.RestoreHealth(hp);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _playerWeapon.Weapon = weapon;
    }
}

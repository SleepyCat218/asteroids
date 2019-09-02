using UnityEngine;

[CreateAssetMenu(fileName = "New weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject
{
    public GameObject ProjectilePrefab;
    public GameObject WeaponModel;
    public float BaseFireDelay = 0.3f;
    public float BaseWeaponDamage = 10f;
    public AudioClip weaponSound;
}

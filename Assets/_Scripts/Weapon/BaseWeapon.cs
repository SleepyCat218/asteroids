using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] protected Weapon _weapon;
    protected GameObject _projectile;
    protected Transform _weaponModel = null;
    protected float _fireDelay = 0.3f;
    protected float _weaponDamage = 10f;
    protected float _nextFire = 0.0f;
    protected AudioSource _audio;
    protected Transform[] _barrels;

    protected void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        LoadWeapon();
    }

    protected void LoadWeapon()
    {
        _projectile = _weapon.ProjectilePrefab;
        _fireDelay = _weapon.BaseFireDelay;
        _weaponDamage = _weapon.BaseWeaponDamage;
        _audio.clip = _weapon.weaponSound;

        if (_weaponModel != null)
        {
            Destroy(_weaponModel.gameObject);
        }
        GameObject newWeaponModel = Instantiate(_weapon.WeaponModel, transform.position, GetProjectileRotation());
        _weaponModel = newWeaponModel.transform;
        _weaponModel.parent = transform;

        WeaponScript weaponScript = _weaponModel.GetComponent<WeaponScript>();
        _barrels = weaponScript.GetBarrels();
    }

    public void Fire()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireDelay;
            foreach (var barrel in _barrels)
            {
                GameObject boltInstance = Instantiate(_projectile, barrel.position, barrel.rotation);
                boltInstance.transform.parent = GameController.Instance.ProjectilesParent;
                BaseShotBehaviour boltBehaviour = boltInstance.GetComponent<BaseShotBehaviour>();
                boltBehaviour.Damage = _weaponDamage;
            }

            if (_audio.clip != null)
            {
                _audio.Play();
            }
        }
    }

    protected abstract Quaternion GetProjectileRotation();
}

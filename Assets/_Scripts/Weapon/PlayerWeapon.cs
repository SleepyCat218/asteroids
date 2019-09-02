using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    private GameObject _projectile;
    private Transform _weaponModel = null;
    private float _fireDelay = 0.3f;
    private float _weaponDamage = 10f;
    private float _nextFire = 0.0f;
    private AudioSource _audio;
    private Transform[] _barrels;

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

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        LoadWeapon();
    }

    private void LoadWeapon()
    {
        _projectile = _weapon.ProjectilePrefab;
        _fireDelay = _weapon.BaseFireDelay;
        _weaponDamage = _weapon.BaseWeaponDamage;
        _audio.clip = _weapon.weaponSound;
        
        if(_weaponModel != null)
        {
            Destroy(_weaponModel.gameObject);
        }
        GameObject newWeaponModel = Instantiate(_weapon.WeaponModel, transform.position, transform.rotation);
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
                PlayerShot boltBehaviour = boltInstance.GetComponent<PlayerShot>();
                boltBehaviour.Damage = _weaponDamage;
            }
            
            if(_audio.clip != null)
            {
                _audio.Play();
            }
        }
    }
}

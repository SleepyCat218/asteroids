using UnityEngine;

public abstract class BaseHealth : MonoBehaviour, IDamageable
{
    [SerializeField] protected GameObject _explosion;
    [SerializeField] protected float _maxHp = 100;
    public float MaxHp
    {
        get
        {
            return _maxHp;
        }
    }

    [SerializeField] protected float _currentHp;
    public virtual float Hp
    {
        get
        {
            return _currentHp;
        }
        protected set
        {
            _currentHp = Mathf.Clamp(value, 0, _maxHp);
        }
    }

    protected bool _isDead;
    public bool IsDead
    {
        get
        {
            return _isDead;
        }
    }

    protected void Awake()
    {
        _currentHp = _maxHp;
    }

    public void GetDamage(float damageValue)
    {
        if (_isDead) return;
        if (_currentHp > 0)
        {
            Hp -= DamageHandling(damageValue);
        }
        if (_currentHp <= 0)
        {
            _isDead = true;
            Die();
        }
    }

    protected abstract float DamageHandling(float damageValue);

    protected virtual void Die()
    {
        _isDead = true;
        GameObject explosion = Instantiate(_explosion, transform.position, transform.rotation);
        explosion.transform.parent = GameController.Instance.ProjectilesParent;
        Destroy(gameObject);
    }
}

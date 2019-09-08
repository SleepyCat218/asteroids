using UnityEngine;
using UnityEngine.UI;

public abstract class PlayerBaseHealth : BaseHealth
{
    [SerializeField] private Slider _healthBar;

    public override float Hp
    {
        get => base.Hp;
        protected set
        {
            base.Hp = value;
            UpdateHealthBar();
        }
    }

    public void RestoreHealth(float hp)
    {
        Hp += hp;
    }

    private void UpdateHealthBar()
    {
        if(_healthBar != null)
        {
            _healthBar.value = _currentHp / _maxHp;
        }
    }

    protected override void Die()
    {
        GameController.Instance.EndGame();
        base.Die();
    }
}

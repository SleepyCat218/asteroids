using UnityEngine;

public abstract class HazardBaseHealth : BaseHealth
{
    [SerializeField] protected int _score = 10;

    protected override void Die()
    {
        GameController.Instance.AddScore(_score);
        base.Die();
    }

    public void DieFromCollision()
    {
        Die();
    }
}

using System.Collections.Generic;
using UnityEngine;

public abstract class HazardBaseHealth : BaseHealth
{
    public event DieDelegate OnDie;

    protected override void Die()
    {
        OnDie?.Invoke();
        base.Die();
    }

    public void DieFromCollision()
    {
        Die();
    }
}

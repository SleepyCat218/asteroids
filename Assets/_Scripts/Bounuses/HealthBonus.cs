using UnityEngine;

public class HealthBonus : BaseBonus
{
    [SerializeField] private float _hp = 5f;

    protected override void ApplyBonus(PlayerController player)
    {
        player.RestoreHealth(_hp);
    }
}

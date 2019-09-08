using UnityEngine;

public class PlayerSimpleHealth : PlayerBaseHealth
{
    protected override float DamageHandling(float damageValue)
    {
        return damageValue;
    }
}

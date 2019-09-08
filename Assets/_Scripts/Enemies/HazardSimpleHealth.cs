using UnityEngine;

public class HazardSimpleHealth : HazardBaseHealth
{
    protected override float DamageHandling(float damageValue)
    {
        return damageValue;
    }
}

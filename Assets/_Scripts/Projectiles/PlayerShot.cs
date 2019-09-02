using UnityEngine;

public class PlayerShot : BaseShotBehaviour
{
    protected override void HitOpponent(Collider opponent)
    {
        HazardHealth enemy = opponent.GetComponent<HazardHealth>();

        if (enemy)
        {
            enemy.GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}

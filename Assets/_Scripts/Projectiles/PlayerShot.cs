using UnityEngine;

public class PlayerShot : BaseShotBehaviour
{
    protected override void HitOpponent(Collider opponent)
    {
        HazardBaseHealth enemy = opponent.GetComponent<HazardBaseHealth>();

        if (enemy)
        {
            enemy.GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}

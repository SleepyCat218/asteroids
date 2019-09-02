using UnityEngine;

public class EnemyShot : BaseShotBehaviour
{
    protected override void HitOpponent(Collider opponent)
    {
        PlayerHealth player = opponent.GetComponent<PlayerHealth>();

        if (player)
        {
            player.GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}

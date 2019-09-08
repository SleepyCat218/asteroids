using UnityEngine;

public class EnemyShot : BaseShotBehaviour
{
    protected override void HitOpponent(Collider opponent)
    {
        PlayerBaseHealth player = opponent.GetComponent<PlayerBaseHealth>();

        if (player)
        {
            player.GetDamage(Damage);
            Destroy(gameObject);
        }
    }
}

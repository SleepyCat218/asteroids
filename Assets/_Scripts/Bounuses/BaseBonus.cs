using UnityEngine;

public abstract class BaseBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player)
        {
            ApplyBonus(player);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyBonus(PlayerController player);
}

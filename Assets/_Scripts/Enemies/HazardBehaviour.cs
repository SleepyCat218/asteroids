using UnityEngine;

public class HazardBehaviour : MonoBehaviour
{
    private HazardHealth _health;
    [SerializeField] private float _collisionDamage = 30f;

    private void Awake()
    {
        _health = GetComponent<HazardHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.GetDamage(_collisionDamage);
            _health.DieFromCollision();
        }
    }
}

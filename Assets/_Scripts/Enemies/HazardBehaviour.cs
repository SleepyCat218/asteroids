using UnityEngine;

public class HazardBehaviour : MonoBehaviour
{
    private HazardBaseHealth _health;
    [SerializeField] private float _collisionDamage = 30f;

    private void Awake()
    {
        _health = GetComponent<HazardBaseHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerBaseHealth playerHealth = other.GetComponent<PlayerBaseHealth>();
        if (playerHealth)
        {
            playerHealth.GetDamage(_collisionDamage);
            _health.DieFromCollision();
        }
    }
}

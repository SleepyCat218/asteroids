using UnityEngine;

public abstract class BaseShotBehaviour : MonoBehaviour
{
    [SerializeField] protected float _speed = 7f;
    protected Rigidbody _rigidbody;
    [HideInInspector] public float Damage;

    protected void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void Start()
    {
        _rigidbody.velocity = transform.forward * _speed;
    }

    protected void OnTriggerEnter(Collider other)
    {
        HitOpponent(other);
    }

    protected abstract void HitOpponent(Collider opponent);
}

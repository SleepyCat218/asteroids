using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rigidbody.angularVelocity = Random.insideUnitSphere * _speed;
    }
}

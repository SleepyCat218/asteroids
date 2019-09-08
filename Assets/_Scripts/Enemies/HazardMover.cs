using UnityEngine;

public class HazardMover : MonoBehaviour
{
    public float speed = 3;
    protected Rigidbody _rigidbody;

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * -1 * speed;
    }
}

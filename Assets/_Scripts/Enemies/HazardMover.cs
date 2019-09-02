using UnityEngine;

public class HazardMover : MonoBehaviour
{
    public float speed = 3;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * -1 * speed;
    }
}

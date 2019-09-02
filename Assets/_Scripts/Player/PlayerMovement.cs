using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5, tilt = 5;
    [SerializeField] private Boundary _boundary;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovePlayer(Vector3 movement)
    {
        _rigidbody.velocity = movement * _speed * Time.fixedDeltaTime;
        _rigidbody.position = new Vector3(Mathf.Clamp(_rigidbody.position.x, _boundary.xMin, _boundary.xMax), 0.0f, _rigidbody.position.z);
        _rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, _rigidbody.velocity.x * -tilt);
    }

    public void StopPlayer()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.position = new Vector3(Mathf.Clamp(_rigidbody.position.x, _boundary.xMin, _boundary.xMax), 0.0f, _rigidbody.position.z);
        _rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, _rigidbody.velocity.x * -tilt);
    }
}

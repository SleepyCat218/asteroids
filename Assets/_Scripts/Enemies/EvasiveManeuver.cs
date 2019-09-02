using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    public float maneuverRange;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;

    [SerializeField] private float _currentSpeed;
    private float _targetManeuver;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _currentSpeed = _rb.velocity.z;
        StartCoroutine(Evade());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            _targetManeuver = Random.Range(1, maneuverRange) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            _targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(_rb.velocity.x, _targetManeuver, Time.fixedDeltaTime * smoothing);
        _rb.velocity = new Vector3(newManeuver, 0.0f, _currentSpeed);
        _rb.position = new Vector3
        (
            Mathf.Clamp(_rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(_rb.position.z, boundary.zMin, boundary.zMax)
        );
        _rb.rotation = Quaternion.Euler(0.0f, 0.0f, _rb.velocity.x * -tilt);
    }
}

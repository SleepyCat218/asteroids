using System.Collections;
using UnityEngine;

public class EnemyWeapon : BaseWeapon
{
    [SerializeField] private float _startDelay = 1f;

    protected override Quaternion GetProjectileRotation()
    {
        return Quaternion.LookRotation(-transform.forward, Vector3.up);
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(StartFire());
    }

    private IEnumerator StartFire()
    {
        yield return new WaitForSeconds(_startDelay);

        while (true)
        {
            Fire();
            yield return new WaitForSeconds(_fireDelay);
        }
    }
}

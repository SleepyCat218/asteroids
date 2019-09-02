using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerWeapon _playerWeapon;
    private PlayerMovement _playerMovement;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _playerWeapon.Fire();
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Abs(horizontal) > 0.1)
        {
            Vector3 movement = new Vector3(
                    horizontal,
                    0.0f,
                    0.0f
                ).normalized;
            _playerMovement.MovePlayer(movement);
        }
        else
        {
            _playerMovement.StopPlayer();
        }
    }

    public void RestoreHealth(float hp)
    {
        _playerHealth.RestoreHealth(hp);
    }

    public void ChangeWeapon(Weapon weapon)
    {
        _playerWeapon.Weapon = weapon;
    }
}

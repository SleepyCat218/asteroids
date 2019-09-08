using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerWeapon _playerWeapon;
    private PlayerMovement _playerMovement;
    

    private void Awake()
    {
        _playerWeapon = GetComponent<PlayerWeapon>();
        _playerMovement = GetComponent<PlayerMovement>();
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
}

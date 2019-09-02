using UnityEngine;

public class DestroyByTimer : MonoBehaviour
{
    [SerializeField] private float _lifetime = 2f;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}

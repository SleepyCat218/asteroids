using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField] private Transform[] _barrels;

    public Transform[] GetBarrels()
    {
        return _barrels;
    }
}

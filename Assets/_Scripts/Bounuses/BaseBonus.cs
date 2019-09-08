using UnityEngine;

public abstract class BaseBonus : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IBonusGetter bonusGetter = other.GetComponent<IBonusGetter>();
        if (bonusGetter != null)
        {
            ApplyBonus(bonusGetter);
            Destroy(gameObject);
        }
    }

    protected abstract void ApplyBonus(IBonusGetter bonusGetter);
}

using UnityEngine;

public class MummyBulletDamage : MonoBehaviour
{
    [SerializeField] public int damageAmount;
    public bool destroyOnHit = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            var damageable = other.GetComponent<PlayerHpSystem>();
            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount);
            }

            if (destroyOnHit)
            {
                Destroy(gameObject);
            }
        }
    }
}

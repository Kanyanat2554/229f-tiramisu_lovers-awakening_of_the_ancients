using TMPro;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    int damageAmount;

    private void Start()
    {
        damageAmount = PlayerDamageStats.damageAmount;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var damageable = other.GetComponent<MummyHpSystem>();
            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount);
            }
        }
    }
}

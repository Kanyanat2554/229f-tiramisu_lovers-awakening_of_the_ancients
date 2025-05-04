using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damageAmount = 5;       
    //public bool destroyOnHit = true;         

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var damageable = other.GetComponent<EnemyHpSystem>();
            if (damageable != null)
            {
                damageable.TakeDamage(damageAmount);
            }

            /*
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }*/
        }
    }
}

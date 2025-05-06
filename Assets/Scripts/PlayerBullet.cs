using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public int damageAmount = 5;
    //public bool destroyOnHit = true;
    private void Start()
    {
        if (PlayerPrefs.GetInt("HasStrengthPotion", 0) == 1)
        {
            damageAmount *= 2;
        }

        Debug.Log($"damageAmount = {damageAmount}");
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

            /*
            if (destroyOnHit)
            {
                Destroy(gameObject);
            }*/
        }
    }
}

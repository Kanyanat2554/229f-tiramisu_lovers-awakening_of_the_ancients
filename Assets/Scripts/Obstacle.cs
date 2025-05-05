using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int minDamage = 1;
    private int maxDamage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int randomDamage = Random.Range(minDamage, maxDamage + 1);

            PlayerHpSystem playerHealth = collision.GetComponent<PlayerHpSystem>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(randomDamage);
            }
        }
    }
}

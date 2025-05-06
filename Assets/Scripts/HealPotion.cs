using UnityEngine;

public class HealPotion : MonoBehaviour
{
    public int healAmount = 25;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHpSystem playerHealth = collision.GetComponent<PlayerHpSystem>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Debug.Log($"Player healed by {healAmount}, current HP: {playerHealth.CurrentHp}");
            }

            Destroy(gameObject);
        }
    }
}

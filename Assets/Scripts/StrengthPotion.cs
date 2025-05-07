using UnityEngine;

public class StrengthPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("HasStrengthPotion", 1);
            PlayerPrefs.Save();

            PlayerDamageStats.damageAmount *= 2;
            Debug.Log($"New player damage: {PlayerDamageStats.damageAmount}");

            Destroy(gameObject);
        }
    }
}

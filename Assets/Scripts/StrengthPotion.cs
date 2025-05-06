using UnityEngine;

public class StrengthPotion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            PlayerPrefs.SetInt("HasStrengthPotion", 1);
            PlayerPrefs.Save();

            
            PlayerBullet playerBullet = collision.GetComponent<PlayerBullet>();
            if (playerBullet != null)
            {
                
                playerBullet.damageAmount *= 2;
                Debug.Log($"[StrengthPotion] Bullet damage set to: {playerBullet.damageAmount}");
            }

            // ทำลาย Potion
            Destroy(gameObject);
        }
    }
}

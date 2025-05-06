using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedPotion : MonoBehaviour
{
    public float speedMultiplier = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            PlayerPrefs.SetInt("HasSpeedPotion", 1);

            
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.MaxSpeed *= speedMultiplier;
                player.Speed = player.MaxSpeed;

                Debug.Log($"New MaxSpeed: {player.MaxSpeed}");
            }

            
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int requiredTreasures = 6;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Treasure.collectedTreasures >= requiredTreasures)
            {
                SceneManager.LoadScene("MainMenu"); 
            }
        }
    }
}

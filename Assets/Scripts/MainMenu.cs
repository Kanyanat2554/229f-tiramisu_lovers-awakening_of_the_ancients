using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.DeleteAll();

        PlayerDamageStats.damageAmount = 5;

        SceneManager.LoadScene("Play");
    }
}

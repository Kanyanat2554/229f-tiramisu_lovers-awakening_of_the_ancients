using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // ���絤�ҡ���� potion
        PlayerPrefs.SetInt("HasSpeedPotion", 0);

        SceneManager.LoadScene("Play");
    }
}

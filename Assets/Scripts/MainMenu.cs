using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // รีเซ็ตค่าการเก็บ potion
        PlayerPrefs.SetInt("HasSpeedPotion", 0);

        SceneManager.LoadScene("Play");
    }
}

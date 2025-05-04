using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHpSystem : MonoBehaviour
{
    // HP System
    public int CurrentHp { get; protected set; }
    public int MaxHp { get; protected set; }

    public Rigidbody2D rb;
    //public HealthBar healthBar;
    //private GameObject healthBarUI;

    private void Awake()
    {
        PlayerPrefs.DeleteKey("PlayerHp"); //test

        if (!PlayerPrefs.HasKey("PlayerHp"))
        {
            PlayerPrefs.SetInt("PlayerHp", 100);
        }

        CurrentHp = PlayerPrefs.GetInt("PlayerHp");
        MaxHp = 100;

        rb = GetComponent<Rigidbody2D>();

        /*
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(MaxHp);
            healthBar.SetHealth(CurrentHp);
        }*/

        Debug.Log($"({this} has {CurrentHp} HP left)");
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        PlayerPrefs.SetInt("PlayerHp", CurrentHp);
        PlayerPrefs.Save();

        /*
        if (healthBar != null)
        {
            healthBar.SetHealth(CurrentHp);
        }*/

        if (IsDead())
        {
            //HideHealthBar();
            Die();
        }

        Debug.Log($"({this} has {CurrentHp} HP left)");
    }

    public bool IsDead()
    {
        return CurrentHp <= 0;
    }

    private void Die()
    {
        Debug.Log("Player Died!");
        PlayerPrefs.DeleteKey("PlayerHp");
        SceneManager.LoadScene("Lose");
        Ring.collectedRings = 0;
    }

    /*private void FindHealthBar()
    {
        GameObject canvas = GameObject.Find("UI_Canvas");
        if (canvas != null)
        {
            healthBar = canvas.GetComponentInChildren<HealthBar>();
            healthBarUI = canvas;

            if (healthBar != null)
            {
                healthBar.SetMaxHealth(MaxHp);
                healthBar.SetHealth(CurrentHp);
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindHealthBar();
    }

    private void HideHealthBar()
    {
        if (healthBarUI != null)
        {
            healthBarUI.SetActive(false);
        }
    }*/
}

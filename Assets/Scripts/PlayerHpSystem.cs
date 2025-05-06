using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHpSystem : MonoBehaviour
{
    // HP System
    public int CurrentHp { get; protected set; }
    public int MaxHp { get; protected set; }

    public Rigidbody2D rb;

    public HealthBar healthBar;
    private GameObject healthBarUI;

    private void Awake()
    {
        MaxHp = 100;
        PlayerPrefs.DeleteKey("PlayerHp"); //test

        if (!PlayerPrefs.HasKey("PlayerHp"))
        {
            CurrentHp = MaxHp;
            PlayerPrefs.SetInt("PlayerHp", CurrentHp);
        }
        else
        {
            CurrentHp = PlayerPrefs.GetInt("PlayerHp");
        }

        rb = GetComponent<Rigidbody2D>();

        
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(MaxHp);
            healthBar.UpdateHealthBar(CurrentHp);
        }

        Debug.Log($"Player HP: {CurrentHp}/{MaxHp}");
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHp -= damage;
        CurrentHp = Mathf.Clamp(CurrentHp, 0, MaxHp);
        PlayerPrefs.SetInt("PlayerHp", CurrentHp);
        PlayerPrefs.Save();

        
        if (healthBar != null)
        {
            healthBar.UpdateHealthBar(CurrentHp);
        }

        if (IsDead())
        {
            HideHealthBar();
            Die();
        }

        Debug.Log($"({this} has {CurrentHp} HP left)");
    }

    public void Heal(int amount)
    {
        CurrentHp += amount;
        CurrentHp = Mathf.Clamp(CurrentHp, 0, MaxHp);

        PlayerPrefs.SetInt("PlayerHp", CurrentHp);
        PlayerPrefs.Save();
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
        Treasure.collectedTreasures = 0;
    }

    private void FindHealthBar()
    {
        GameObject canvas = GameObject.Find("UI_Canvas");
        if (canvas != null)
        {
            healthBar = canvas.GetComponentInChildren<HealthBar>();
            healthBarUI = canvas;

            if (healthBar != null)
            {
                healthBar.SetMaxHealth(MaxHp);
                healthBar.UpdateHealthBar(CurrentHp);
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
    }
}

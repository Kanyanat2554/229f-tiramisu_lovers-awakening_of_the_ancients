using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MummyHpSystem : MonoBehaviour
{
    [SerializeField] public int maxHp;
    private int currentHp;

    public GameObject deathPrefab; //new prefab to display

    public Slider healthSlider;

    private void Start()
    {
        currentHp = maxHp;
        healthSlider.maxValue = maxHp;
        healthSlider.value = currentHp;
    }


    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        currentHp = Mathf.Clamp(currentHp, 0, maxHp);
        healthSlider.value = currentHp;

        if (currentHp <= 0)
        {
            
            Die();
        }
        Debug.Log($"{this} has {currentHp} Hp");
    }

    private void Die()
    {
        if (deathPrefab != null)
        {
            Vector3 spawnOffset = new Vector3(0f, -0.7f, 0f);
            Instantiate(deathPrefab, transform.position + spawnOffset, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}

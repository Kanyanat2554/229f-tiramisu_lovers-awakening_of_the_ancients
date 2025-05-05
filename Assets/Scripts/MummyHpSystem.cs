using System.Collections.Generic;
using UnityEngine;

public class MummyHpSystem : MonoBehaviour
{
    [SerializeField] public int maxHp;
    private int currentHp;

    public GameObject deathPrefab; //new prefab to display
    

    private void Start()
    {
        currentHp = maxHp;
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

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

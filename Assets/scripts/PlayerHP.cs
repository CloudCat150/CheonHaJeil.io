using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 50; // 최대 체력
    public int currentHealth;  // 현재 체력

    void Start()
    {
        currentHealth = maxHealth; // 시작 시 최대 체력으로 설정
    }

    public void TakeDamage(int damage, bool die = false)
    {
        currentHealth -= damage; // 데미지 받음

        if (!die && currentHealth <= 0)
        {
            currentHealth = 1;
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 체력 범위 제한
        }

        Debug.Log("Current Health: " + currentHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // 체력 회복
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 체력 범위 제한
        Debug.Log("Current Health: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Player has died.");
        FindObjectOfType<DeathEffectManager>().OnPlayerDeath(); // DeathEffectManager와 연동
    }
}

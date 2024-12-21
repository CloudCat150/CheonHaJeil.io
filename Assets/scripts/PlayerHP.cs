using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 50; // �ִ� ü��
    public int currentHealth;  // ���� ü��

    void Start()
    {
        currentHealth = maxHealth; // ���� �� �ִ� ü������ ����
    }

    public void TakeDamage(int damage, bool die = false)
    {
        currentHealth -= damage; // ������ ����

        if (!die && currentHealth <= 0)
        {
            currentHealth = 1;
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ü�� ���� ����
        }

        Debug.Log("Current Health: " + currentHealth);

        if (currentHealth == 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount; // ü�� ȸ��
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // ü�� ���� ����
        Debug.Log("Current Health: " + currentHealth);
    }

    void Die()
    {
        Debug.Log("Player has died.");
        FindObjectOfType<DeathEffectManager>().OnPlayerDeath(); // DeathEffectManager�� ����
    }
}

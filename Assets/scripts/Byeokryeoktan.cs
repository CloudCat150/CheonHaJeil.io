using UnityEngine;

public class Byeokryeoktan : MonoBehaviour
{
    public float currentHealth = 50f;  // ���� �⺻ ü�� (50)

    // �������� �޴� �Լ�
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ���� �׾��� �� ȣ��Ǵ� �Լ�
    private void Die()
    {
        // �׾��� ���� ó�� (��: ���� ������Ʈ ����)
        Debug.Log("Enemy has died.");
        Destroy(gameObject);
    }
}

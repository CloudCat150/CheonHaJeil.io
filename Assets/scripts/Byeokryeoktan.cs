using UnityEngine;

public class Byeokryeoktan : MonoBehaviour
{
    public float currentHealth = 50f;  // 적의 기본 체력 (50)

    // 데미지를 받는 함수
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 적이 죽었을 때 호출되는 함수
    private void Die()
    {
        // 죽었을 때의 처리 (예: 게임 오브젝트 삭제)
        Debug.Log("Enemy has died.");
        Destroy(gameObject);
    }
}

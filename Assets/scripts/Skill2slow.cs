using System.Collections;
using UnityEngine;

public class Skill2Slow : MonoBehaviour
{
    public float slowDuration = 2f; // 둔화 지속 시간

    private void Start()
    {
        Debug.Log("Skill2Slow 스크립트 활성화됨");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ob"))
        {
            Debug.Log("Enemy와 충돌 발생!");

            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // 둔화 효과 적용
                StartCoroutine(ApplySlowEffect(collision.gameObject));
                Debug.Log("Skill2slow is on playing");
            }
            else
            {
                Debug.LogWarning("Enemy에 Rigidbody2D가 없습니다!");
            }
        }
    }

    private IEnumerator ApplySlowEffect(GameObject enemy)
    {
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.ApplySlow(slowDuration);
            Debug.Log("둔화 효과 적용!");
            yield return new WaitForSeconds(slowDuration);
            enemyController.RemoveSlow();
            Debug.Log("둔화 효과 해제!");
        }
        else
        {
            Debug.LogWarning("EnemyController 스크립트를 찾을 수 없습니다!");
        }
    }
}

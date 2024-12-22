using System.Collections;
using UnityEngine;

public class Skill2Slow : MonoBehaviour
{
    public float slowDuration = 2f; // ��ȭ ���� �ð�

    private void Start()
    {
        Debug.Log("Skill2Slow ��ũ��Ʈ Ȱ��ȭ��");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ob"))
        {
            Debug.Log("Enemy�� �浹 �߻�!");

            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (enemyRigidbody != null)
            {
                // ��ȭ ȿ�� ����
                StartCoroutine(ApplySlowEffect(collision.gameObject));
                Debug.Log("Skill2slow is on playing");
            }
            else
            {
                Debug.LogWarning("Enemy�� Rigidbody2D�� �����ϴ�!");
            }
        }
    }

    private IEnumerator ApplySlowEffect(GameObject enemy)
    {
        EnemyController enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.ApplySlow(slowDuration);
            Debug.Log("��ȭ ȿ�� ����!");
            yield return new WaitForSeconds(slowDuration);
            enemyController.RemoveSlow();
            Debug.Log("��ȭ ȿ�� ����!");
        }
        else
        {
            Debug.LogWarning("EnemyController ��ũ��Ʈ�� ã�� �� �����ϴ�!");
        }
    }
}

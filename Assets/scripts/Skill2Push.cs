using UnityEngine;

public class Skill2Push : MonoBehaviour
{
    public GameObject Player; // Player ������Ʈ
    public float pushForce = 5f; // �о�� ��

    private void Start()
    {
        // ��ũ��Ʈ�� ���۵Ǿ��� �� �޽����� ����Ͽ� ��ũ��Ʈ�� Ȱ��ȭ�Ǿ����� Ȯ��
        Debug.Log("PushObject ��ũ��Ʈ ����");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �浹�� ������Ʈ�� �̸��� ���
        Debug.Log($"�浹�� ������Ʈ: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Ob"))
        {
            Debug.Log("Ob �±׿� �浹 �߻�!");

            Vector3 playerPosition = Player.transform.position;
            Vector3 obPosition = collision.gameObject.transform.position;

            Vector3 pushDirection = (obPosition - playerPosition).normalized;

            Rigidbody2D obRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (obRigidbody != null)
            {
                obRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                Debug.Log("Ob ������Ʈ �и�");
            }
        }
    }
}
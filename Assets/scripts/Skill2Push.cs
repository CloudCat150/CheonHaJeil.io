using UnityEngine;

public class Skill2Push : MonoBehaviour
{
    public GameObject Player; // Player ������Ʈ
    public float pushForce = 5f; // �о�� ��

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Ob"))
        {
            Vector3 playerPosition = Player.transform.position;
            Vector3 obPosition = collision.gameObject.transform.position;

            Vector3 pushDirection = (obPosition - playerPosition).normalized;

            Rigidbody2D obRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (obRigidbody != null)
            {
                obRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
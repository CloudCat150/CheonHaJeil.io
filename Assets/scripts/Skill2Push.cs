using UnityEngine;

public class Skill2Push : MonoBehaviour
{
    public GameObject Player; // Player 오브젝트
    public float pushForce = 5f; // 밀어내는 힘

    private void Start()
    {
        // 스크립트가 시작되었을 때 메시지를 출력하여 스크립트가 활성화되었는지 확인
        Debug.Log("PushObject 스크립트 시작");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 이름을 출력
        Debug.Log($"충돌한 오브젝트: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Ob"))
        {
            Debug.Log("Ob 태그와 충돌 발생!");

            Vector3 playerPosition = Player.transform.position;
            Vector3 obPosition = collision.gameObject.transform.position;

            Vector3 pushDirection = (obPosition - playerPosition).normalized;

            Rigidbody2D obRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (obRigidbody != null)
            {
                obRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
                Debug.Log("Ob 오브젝트 밀림");
            }
        }
    }
}
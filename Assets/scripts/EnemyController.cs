using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float normalSpeed = 5f; // �⺻ �ӵ�
    private float currentSpeed;   // ���� �ӵ�
    private bool isSlowed = false; // ��ȭ ���� Ȯ��

    private void Start()
    {
        currentSpeed = normalSpeed; // �ʱ� �ӵ� ����
    }

    private void Update()
    {
        // �� �̵� ���� (����)
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void ApplySlow(float duration)
    {
        if (!isSlowed) // �̹� ��ȭ ���°� �ƴ϶��
        {
            isSlowed = true;
            currentSpeed = normalSpeed / 2; // �ӵ��� �������� ����
            Invoke(nameof(RemoveSlow), duration); // ���� �ð� �� ��ȭ ����
        }
    }

    public void RemoveSlow()
    {
        isSlowed = false;
        currentSpeed = normalSpeed; // �ӵ� ����
    }
}

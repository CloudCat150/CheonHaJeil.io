using System.Collections;
using UnityEngine;

public class Jeommyeol : MonoBehaviour
{
    public float flashDistance = 5f; // ���� �Ÿ�
    public float cooldownTime = 30f; // ��Ÿ�� �ð�
    private bool isOnCooldown = false; // ���� ��� ���� ����
    private Coroutine flashCoroutine; // ���� �̵� ó�� �ڷ�ƾ
    private SpriteRenderer spriteRenderer; // SpriteRenderer ������Ʈ
    private Color originalColor; // ���� ���� ����

    void Start()
    {
        // SpriteRenderer ������Ʈ�� �������� (2D ���ӿ��� ���)
        spriteRenderer = GetComponent<SpriteRenderer>();
        // ���� ���� ����
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // ���� Ű �Է� (Q Ű)
        if (Input.GetKeyDown(KeyCode.Q) && !isOnCooldown)
        {
            Vector3 targetPosition = transform.position + transform.right * flashDistance; // X�� �������� ����
            if (flashCoroutine == null)
            {
                flashCoroutine = StartCoroutine(FlashMovement(targetPosition));
            }
        }
    }

    private IEnumerator FlashMovement(Vector3 targetPosition)
    {
        // ���� ���� �� ���� ó�� (������ ������ ���� �ʵ��� 0.3f�� ����)
        SetTransparency(0.3f); // ���� �� 30% ����

        // ���� �̵��� 3������ ���� ó��
        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetPosition;

        for (int i = 0; i < 3; i++) // 3������ ���� �̵�
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (i + 1) / 3f);
            yield return null; // ���� �����ӱ��� ���
        }

        transform.position = endPosition; // ���� ��ġ ����

        // ���� �Ϸ� �� ���� ���·� ���ư� (������)
        SetTransparency(1f); // ���� ������ ����

        // ���� �Ϸ� �� ��Ÿ�� ����
        StartCoroutine(FlashCooldown());
        flashCoroutine = null;
    }

    private void SetTransparency(float alpha)
    {
        // SpriteRenderer�� ���� �� ����
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    private IEnumerator FlashCooldown()
    {
        isOnCooldown = true; // ��Ÿ�� Ȱ��ȭ
        Debug.Log("���� ��Ÿ�� ����!");

        yield return new WaitForSeconds(cooldownTime); // 30�� ���

        isOnCooldown = false; // ��Ÿ�� ����
        Debug.Log("���� �غ� �Ϸ�!");
    }
}

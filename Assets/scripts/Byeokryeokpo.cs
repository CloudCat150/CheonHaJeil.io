using UnityEngine;

public class Byeokryeokpo : MonoBehaviour
{
    public GameObject cannonballPrefab; // ��ź ������
    public Transform firePoint;         // ��ź �߻� ��ġ
    public float fireForce = 10f;       // ��ź �߻� ��
    public float cooldownTime = 40f;    // ��Ÿ��
    private bool isOnCooldown = false;

    void Update()
    {
        // QŰ�� ������ ���� ��ź �߻�
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isOnCooldown)
            {
                FireCannon(); // ��ź �߻�
                isOnCooldown = true;
                Invoke("ResetCooldown", cooldownTime); // ��Ÿ�� ����
            }
            else
            {
                Debug.Log("Cannon is on cooldown!");
            }
        }
    }

    // ��ź �߻� �޼���
    void FireCannon()
    {
        // ��ź ������Ʈ�� �߻� ��ġ���� ����
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, Quaternion.identity);

        // Rigidbody2D ��������
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();

        // Rigidbody2D�� ������ isKinematic�� false�� �����Ͽ� ���� ������ ������ �ް� ��
        if (rb != null)
        {
            rb.isKinematic = false; // �߻� �� ���� ���� ����
            rb.AddForce(transform.right * fireForce, ForceMode2D.Impulse); // �߻� ���⿡ ���� ��
        }

        Debug.Log("Cannon fired!");
    }

    // ��Ÿ�� ���� �޼���
    void ResetCooldown()
    {
        isOnCooldown = false;
        Debug.Log("Cannon is ready to fire again.");
    }
}

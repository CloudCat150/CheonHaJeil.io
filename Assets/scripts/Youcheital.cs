using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youcheital : MonoBehaviour
{
    public float skillDuration = 10f; // ��ų ���� �ð� (10��)
    public float cooldownTime = 30f;  // ��Ÿ�� (30��)
    private Vector3 initialPosition;
    private bool skillCast = false;   // ��ų�� ���� ������ üũ
    private bool isOnCooldown = false; // ��Ÿ�� ������ üũ

    // ��ų ���� �� ȣ��Ǵ� �Լ�
    public void CastSkill()
    {
        if (isOnCooldown)
        {
            Debug.Log("Skill is on cooldown!");
            return; // ��Ÿ�� ���̸� ��ų�� ������ �� ����
        }

        initialPosition = transform.position; // ��ų ������ ��ġ ����
        skillCast = true;
        Debug.Log("Skill casted, will return in " + skillDuration + " seconds.");
        Invoke("ReturnToInitialPosition", skillDuration); // 10�� �� �ǵ��ƿ���
        isOnCooldown = true; // ��Ÿ�� ����
        Invoke("ResetCooldown", cooldownTime); // 30�� �� ��Ÿ�� ����
    }

    // ���� �ð��� ���� �� �ǵ��ƿ��� �Լ�
    private void ReturnToInitialPosition()
    {
        transform.position = initialPosition; // ����� �ʱ� ��ġ�� �ǵ��ư�
        skillCast = false; // ��ų�� �������� ǥ��
        Debug.Log("Returned to initial position.");
    }

    // ��Ÿ�� ���� �Լ�
    private void ResetCooldown()
    {
        isOnCooldown = false; // ��Ÿ�� ����
        Debug.Log("Skill cooldown ended, ready to cast again.");
    }

    // Update�� ����ؼ� �Է��� Ȯ��
    void Update()
    {
        // QŰ�� ������ �� CastSkill�� ȣ��
        if (Input.GetKeyDown(KeyCode.Q) && !skillCast)
        {
            CastSkill();
        }
    }
}

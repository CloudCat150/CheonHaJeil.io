using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakSa : MonoBehaviour
{
    // Trigger �ȿ� �� ���¸� �����ϴ� ����
    private bool isInsideTrigger = false;

    // �ٸ� ������Ʈ�� Trigger ������ ���� �� ȣ��˴ϴ�.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Background")) // Background �±׸� ���� ������Ʈ�͸� ����
        {
            isInsideTrigger = true;
            Debug.Log("Player entered the trigger.");
        }
    }

    // �ٸ� ������Ʈ�� Trigger���� ���� �� ȣ��˴ϴ�.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Background")) // Background �±׸� ���� ������Ʈ�͸� ����
        {
            isInsideTrigger = false;
            Debug.Log("Player exited the trigger.");
            EndGame(); // ���� ����
        }
    }

    // ���� ���� ó�� �޼���
    private void EndGame()
    {
        Debug.Log("Game Over!");
        // ���� ���� ���� (�ʿ��ϸ� �߰�)
        Application.Quit(); // ������ �����մϴ�. �����Ϳ����� �۵����� ������ �����ϼ���.
    }
}
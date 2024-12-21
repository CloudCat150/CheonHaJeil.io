using System.Collections;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public GameObject targetObject; // Ȱ��ȭ/��Ȱ��ȭ�� �ٸ� ������Ʈ

    void Update()
    {
        // ��Ŭ�� ����
        if (Input.GetMouseButtonDown(1)) // 1: ��Ŭ��
        {
            if (targetObject != null)
            {
                StartCoroutine(ActivateAndDeactivate());
            }
            else
            {
                Debug.LogWarning("Target object is not assigned!");
            }
        }
    }

    IEnumerator ActivateAndDeactivate()
    {
        // ������Ʈ Ȱ��ȭ
        targetObject.SetActive(true);
        yield return new WaitForSeconds(0.2f); // 2�� ���
        targetObject.SetActive(false);      // ������Ʈ ��Ȱ��ȭ
    }
}
using System.Collections;
using UnityEngine;

public class Skill2 : MonoBehaviour
{
    public GameObject targetObject; // 활성화/비활성화할 다른 오브젝트

    void Update()
    {
        // 우클릭 감지
        if (Input.GetMouseButtonDown(1)) // 1: 우클릭
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
        // 오브젝트 활성화
        targetObject.SetActive(true);
        yield return new WaitForSeconds(2f); // 2초 대기
        targetObject.SetActive(false);      // 오브젝트 비활성화
    }
}
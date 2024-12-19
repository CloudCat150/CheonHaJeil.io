using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NakSa : MonoBehaviour
{
    // Trigger 안에 들어간 상태를 추적하는 변수
    private bool isInsideTrigger = false;

    // 다른 오브젝트가 Trigger 안으로 들어올 때 호출됩니다.
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Background")) // Background 태그를 가진 오브젝트와만 반응
        {
            isInsideTrigger = true;
            Debug.Log("Player entered the trigger.");
        }
    }

    // 다른 오브젝트가 Trigger에서 나갈 때 호출됩니다.
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Background")) // Background 태그를 가진 오브젝트와만 반응
        {
            isInsideTrigger = false;
            Debug.Log("Player exited the trigger.");
            EndGame(); // 게임 종료
        }
    }

    // 게임 종료 처리 메서드
    private void EndGame()
    {
        Debug.Log("Game Over!");
        // 게임 종료 로직 (필요하면 추가)
        Application.Quit(); // 게임을 종료합니다. 에디터에서는 작동하지 않으니 주의하세요.
    }
}
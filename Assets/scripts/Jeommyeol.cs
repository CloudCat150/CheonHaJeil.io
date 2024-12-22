using System.Collections;
using UnityEngine;

public class Jeommyeol : MonoBehaviour
{
    public float flashDistance = 5f; // 점멸 거리
    public float cooldownTime = 30f; // 쿨타임 시간
    private bool isOnCooldown = false; // 점멸 사용 가능 여부
    private Coroutine flashCoroutine; // 점멸 이동 처리 코루틴
    private SpriteRenderer spriteRenderer; // SpriteRenderer 컴포넌트
    private Color originalColor; // 원래 색상 저장

    void Start()
    {
        // SpriteRenderer 컴포넌트를 가져오기 (2D 게임에서 사용)
        spriteRenderer = GetComponent<SpriteRenderer>();
        // 원래 색상 저장
        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        // 점멸 키 입력 (Q 키)
        if (Input.GetKeyDown(KeyCode.Q) && !isOnCooldown)
        {
            Vector3 targetPosition = transform.position + transform.right * flashDistance; // X축 방향으로 점멸
            if (flashCoroutine == null)
            {
                flashCoroutine = StartCoroutine(FlashMovement(targetPosition));
            }
        }
    }

    private IEnumerator FlashMovement(Vector3 targetPosition)
    {
        // 점멸 시작 시 투명 처리 (완전히 보이지 않지 않도록 0.3f로 설정)
        SetTransparency(0.3f); // 점멸 중 30% 투명

        // 점멸 이동을 3프레임 동안 처리
        Vector3 startPosition = transform.position;
        Vector3 endPosition = targetPosition;

        for (int i = 0; i < 3; i++) // 3프레임 동안 이동
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (i + 1) / 3f);
            yield return null; // 다음 프레임까지 대기
        }

        transform.position = endPosition; // 최종 위치 설정

        // 점멸 완료 후 원래 상태로 돌아감 (불투명)
        SetTransparency(1f); // 원래 불투명 상태

        // 점멸 완료 후 쿨타임 시작
        StartCoroutine(FlashCooldown());
        flashCoroutine = null;
    }

    private void SetTransparency(float alpha)
    {
        // SpriteRenderer의 알파 값 조정
        Color color = spriteRenderer.color;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    private IEnumerator FlashCooldown()
    {
        isOnCooldown = true; // 쿨타임 활성화
        Debug.Log("점멸 쿨타임 시작!");

        yield return new WaitForSeconds(cooldownTime); // 30초 대기

        isOnCooldown = false; // 쿨타임 종료
        Debug.Log("점멸 준비 완료!");
    }
}

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float normalSpeed = 5f; // 기본 속도
    private float currentSpeed;   // 현재 속도
    private bool isSlowed = false; // 둔화 상태 확인

    private void Start()
    {
        currentSpeed = normalSpeed; // 초기 속도 설정
    }

    private void Update()
    {
        // 적 이동 로직 (예시)
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
    }

    public void ApplySlow(float duration)
    {
        if (!isSlowed) // 이미 둔화 상태가 아니라면
        {
            isSlowed = true;
            currentSpeed = normalSpeed / 2; // 속도를 절반으로 감소
            Invoke(nameof(RemoveSlow), duration); // 일정 시간 후 둔화 해제
        }
    }

    public void RemoveSlow()
    {
        isSlowed = false;
        currentSpeed = normalSpeed; // 속도 복구
    }
}

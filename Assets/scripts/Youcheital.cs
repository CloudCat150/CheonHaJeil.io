using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Youcheital : MonoBehaviour
{
    public float skillDuration = 10f; // 스킬 지속 시간 (10초)
    public float cooldownTime = 30f;  // 쿨타임 (30초)
    private Vector3 initialPosition;
    private bool skillCast = false;   // 스킬이 시전 중인지 체크
    private bool isOnCooldown = false; // 쿨타임 중인지 체크

    // 스킬 시전 시 호출되는 함수
    public void CastSkill()
    {
        if (isOnCooldown)
        {
            Debug.Log("Skill is on cooldown!");
            return; // 쿨타임 중이면 스킬을 시전할 수 없음
        }

        initialPosition = transform.position; // 스킬 시전한 위치 저장
        skillCast = true;
        Debug.Log("Skill casted, will return in " + skillDuration + " seconds.");
        Invoke("ReturnToInitialPosition", skillDuration); // 10초 후 되돌아오기
        isOnCooldown = true; // 쿨타임 시작
        Invoke("ResetCooldown", cooldownTime); // 30초 후 쿨타임 리셋
    }

    // 일정 시간이 지난 후 되돌아오는 함수
    private void ReturnToInitialPosition()
    {
        transform.position = initialPosition; // 저장된 초기 위치로 되돌아감
        skillCast = false; // 스킬이 끝났음을 표시
        Debug.Log("Returned to initial position.");
    }

    // 쿨타임 리셋 함수
    private void ResetCooldown()
    {
        isOnCooldown = false; // 쿨타임 종료
        Debug.Log("Skill cooldown ended, ready to cast again.");
    }

    // Update는 계속해서 입력을 확인
    void Update()
    {
        // Q키를 눌렀을 때 CastSkill을 호출
        if (Input.GetKeyDown(KeyCode.Q) && !skillCast)
        {
            CastSkill();
        }
    }
}

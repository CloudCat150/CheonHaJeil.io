using UnityEngine;

public class Byeokryeokpo : MonoBehaviour
{
    public GameObject cannonballPrefab; // 포탄 프리팹
    public Transform firePoint;         // 포탄 발사 위치
    public float fireForce = 10f;       // 포탄 발사 힘
    public float cooldownTime = 40f;    // 쿨타임
    private bool isOnCooldown = false;

    void Update()
    {
        // Q키를 눌렀을 때만 포탄 발사
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!isOnCooldown)
            {
                FireCannon(); // 포탄 발사
                isOnCooldown = true;
                Invoke("ResetCooldown", cooldownTime); // 쿨타임 리셋
            }
            else
            {
                Debug.Log("Cannon is on cooldown!");
            }
        }
    }

    // 포탄 발사 메서드
    void FireCannon()
    {
        // 포탄 오브젝트를 발사 위치에서 생성
        GameObject cannonball = Instantiate(cannonballPrefab, firePoint.position, Quaternion.identity);

        // Rigidbody2D 가져오기
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();

        // Rigidbody2D가 있으면 isKinematic을 false로 설정하여 물리 엔진에 영향을 받게 함
        if (rb != null)
        {
            rb.isKinematic = false; // 발사 시 물리 엔진 적용
            rb.AddForce(transform.right * fireForce, ForceMode2D.Impulse); // 발사 방향에 힘을 줌
        }

        Debug.Log("Cannon fired!");
    }

    // 쿨타임 리셋 메서드
    void ResetCooldown()
    {
        isOnCooldown = false;
        Debug.Log("Cannon is ready to fire again.");
    }
}

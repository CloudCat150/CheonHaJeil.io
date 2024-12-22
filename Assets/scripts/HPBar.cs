using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider; // 체력바 UI 슬라이더
    public PlayerHP playerHealth; // PlayerHealth 스크립트

    void Start()
    {
        slider.maxValue = playerHealth.maxHealth; // 슬라이더 최대값 설정
        slider.value = playerHealth.currentHealth; // 초기 슬라이더 값 설정
    }

    void Update()
    {
        slider.value = playerHealth.currentHealth; // 체력 값 업데이트
    }
}
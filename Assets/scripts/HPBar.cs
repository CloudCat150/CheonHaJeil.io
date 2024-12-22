using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider; // ü�¹� UI �����̴�
    public PlayerHP playerHealth; // PlayerHealth ��ũ��Ʈ

    void Start()
    {
        slider.maxValue = playerHealth.maxHealth; // �����̴� �ִ밪 ����
        slider.value = playerHealth.currentHealth; // �ʱ� �����̴� �� ����
    }

    void Update()
    {
        slider.value = playerHealth.currentHealth; // ü�� �� ������Ʈ
    }
}
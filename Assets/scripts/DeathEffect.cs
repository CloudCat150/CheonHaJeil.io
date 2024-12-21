using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class DeathEffectManager : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; // Post-Processing Volume
    private ColorGrading colorGrading;

    public Image distortionEffect; // ������ ȭ�� ȿ�� �̹���
    public Text deathText; // �߾ӿ� ǥ���� ���� �ؽ�Ʈ

    private int deathCount = 0; // ���� Ƚ��

    void Start()
    {
        // Post-Processing Color Grading ���� ��������
        if (postProcessVolume.profile.TryGetSettings(out ColorGrading grading))
        {
            colorGrading = grading;
        }

        // �ʱ� UI ����
        distortionEffect.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        deathCount++; // ���� Ƚ�� ����

        // 1. ȭ�� ä�� ��Ӱ�
        if (colorGrading != null)
        {
            colorGrading.saturation.value = -100; // ä�� ��Ӱ�
        }

        // 2. ȭ�� ������ ȿ�� Ȱ��ȭ
        distortionEffect.gameObject.SetActive(true);
        StartCoroutine(FadeInImage(distortionEffect, 1.0f)); // ������ ��Ÿ����

        // 3. ���� Ƚ�� �ؽ�Ʈ ǥ��
        string message = "";
        switch (deathCount)
        {
            case 1:
                message = "OUT";
                break;
            case 2:
                message = "2 OUT";
                break;
            case 3:
                message = "3 OUT GAME OVER";
                break;
            default:
                message = "GAME OVER";
                break;
        }

        deathText.text = message;
        deathText.gameObject.SetActive(true);
    }

    private IEnumerator FadeInImage(Image image, float duration)
    {
        Color color = image.color;
        float alpha = 0;
        image.color = new Color(color.r, color.g, color.b, alpha);

        while (alpha < 1)
        {
            alpha += Time.deltaTime / duration;
            image.color = new Color(color.r, color.g, color.b, alpha);
            yield return null;
        }
    }
}
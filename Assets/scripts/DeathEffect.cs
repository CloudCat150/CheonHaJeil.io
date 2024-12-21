using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class DeathEffectManager : MonoBehaviour
{
    public PostProcessVolume postProcessVolume; // Post-Processing Volume
    private ColorGrading colorGrading;

    public Image distortionEffect; // 구겨진 화면 효과 이미지
    public Text deathText; // 중앙에 표시할 죽음 텍스트

    private int deathCount = 0; // 죽음 횟수

    void Start()
    {
        // Post-Processing Color Grading 설정 가져오기
        if (postProcessVolume.profile.TryGetSettings(out ColorGrading grading))
        {
            colorGrading = grading;
        }

        // 초기 UI 숨김
        distortionEffect.gameObject.SetActive(false);
        deathText.gameObject.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        deathCount++; // 죽음 횟수 증가

        // 1. 화면 채도 어둡게
        if (colorGrading != null)
        {
            colorGrading.saturation.value = -100; // 채도 어둡게
        }

        // 2. 화면 구겨진 효과 활성화
        distortionEffect.gameObject.SetActive(true);
        StartCoroutine(FadeInImage(distortionEffect, 1.0f)); // 서서히 나타나게

        // 3. 죽음 횟수 텍스트 표시
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
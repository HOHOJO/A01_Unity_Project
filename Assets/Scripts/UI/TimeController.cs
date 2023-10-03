using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public Slider timerSlider;
    public float totalTime = 120f;
    private float currentTime = 0f;

    private float sliderSpeed = 2.0f;
    public GameObject stageClearPanel;

    public GameProgress gameProgress;
    private void Start()
    {
        currentTime = 0f; // slider ������ġ 0���� ����
        UpdateSlider();
    }

    // Update is called once per frame
    void Update()
    {
        // �ð��� �带 ������ ����
        currentTime += Time.deltaTime * sliderSpeed / totalTime;

        // �ð��� 0 �Ǵ� 1�� ����� �ʵ��� ����
        currentTime = Mathf.Clamp01(currentTime);
        
        if (currentTime == 0f)
        {
            ActivateStageClearPanel();
        }

        UpdateSlider();
    }

    private void UpdateSlider()
    {
        timerSlider.value = currentTime;
    }

    private void ActivateStageClearPanel()
    {
        // StageClearPanel�� Ȱ��ȭ
        stageClearPanel.SetActive(true);
    }

    public void ResetTime()
    {
        currentTime = 0f;
        UpdateSlider();
    }
}

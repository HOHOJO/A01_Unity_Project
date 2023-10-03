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
        currentTime = 0f; // slider 시작위치 0에서 시작
        UpdateSlider();
    }

    // Update is called once per frame
    void Update()
    {
        // 시간이 흐를 때마다 감소
        currentTime += Time.deltaTime * sliderSpeed / totalTime;

        // 시간이 0 또는 1을 벗어나지 않도록 보정
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
        // StageClearPanel을 활성화
        stageClearPanel.SetActive(true);
    }

    public void ResetTime()
    {
        currentTime = 0f;
        UpdateSlider();
    }
}

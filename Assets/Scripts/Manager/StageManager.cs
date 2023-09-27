using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public TextMeshProUGUI stageText;
    private int currentStage = 1;

    public GameObject zombies;
    public GameObject Plants;

    void Start()
    {
        // 초기 스테이지
        SetStage(currentStage);
    }

    public void NextStage()
    {
        currentStage++; // 다음스테이지로 이동
        SetStage(currentStage);
    }

    private void SetStage(int stageNum)
    {
        stageText.text = stageNum.ToString();

        if(zombies != null)
        {
            Destroy(zombies);
        }

        if(Plants != null)
        {
            Destroy(Plants);
        }
    }
}

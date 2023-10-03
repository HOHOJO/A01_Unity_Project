using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public TextMeshProUGUI stageText;
    private int currentStage = 1;

    public GameObject zombies;
    public GameObject plants;
    public GameObject stageClearPanel;
    public Button nextStageBtn;
    public Button selectStageBtn;
    public Button retryBtn;
    public Button gameEndBtn;

    void Start()
    {
        // 초기 스테이지
        SetStage(currentStage);
        nextStageBtn.onClick.AddListener(NextStage);
        selectStageBtn.onClick.AddListener(SelectStage);
        retryBtn.onClick.AddListener(RetryStage);
        gameEndBtn.onClick.AddListener(StartMenuStage);
    }

    public void NextStage()
    {
        currentStage++; // 다음스테이지로 이동
        // 스테이지가 올라갈 때 골드 +1000 
        PlayerGold playergold = FindObjectOfType<PlayerGold>(); 
        if(playergold != null)
        {
            playergold.CurrentGold += 1000;
        }
        SetStage(currentStage);
    }

    private void SetStage(int stageNum)
    {
        stageText.text = stageNum.ToString();

        // 이전 스테이지의 플레이어 오브젝트, 적 오브젝트 모두 제거
        if(zombies != null)
        {
            Destroy(zombies);
        }

        if(plants != null)
        {
            Destroy(plants);
        }

        stageClearPanel.SetActive(false);
    }

    void SelectStage()
    {
        SceneManager.LoadScene(2);
    }

    void RetryStage()
    {
        SceneManager.LoadScene(0);
    }

    void StartMenuStage()
    {
        SceneManager.LoadScene(1);
    }
}

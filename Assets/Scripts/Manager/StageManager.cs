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
        TimeController timeController = FindObjectOfType<TimeController>();
        if(timeController != null)
        {
            timeController.ResetTime();
        }

        SetStage(currentStage);
    }

    private void SetStage(int stageNum)
    {
        stageText.text = stageNum.ToString();

        // 이전 스테이지의 플레이어 오브젝트, 적 오브젝트 모두 제거
        if(gameObject.tag == "tower")
        {
            Destroy(gameObject); // "tower"태그 가진 현재 게임 오브젝트 파괴
        }

        if(gameObject.tag == "enemy")
        {
            Destroy(gameObject); // "enemy"태그 가진 현재 게임 오브젝트 파괴
        }

        stageClearPanel.SetActive(false);
    }

    public void SelectStage()
    {
        //SceneManager.LoadScene(2);
    }

    public void RetryStage()
    {
        if (gameObject.tag == "tower")
        {
            Destroy(this.gameObject); // "tower"태그 가진 현재 게임 오브젝트 파괴
        }

        if (gameObject.tag == "enemy")
        {
            Destroy(this.gameObject); // "enemy"태그 가진 현재 게임 오브젝트 파괴
        }
        Time.timeScale = 0;
        Time.timeScale = 1;
    }

    public void StartMenuStage()
    {
        //SceneManager.LoadScene(1);
    }
}

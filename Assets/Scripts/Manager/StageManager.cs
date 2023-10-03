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
        // �ʱ� ��������
        SetStage(currentStage);
        nextStageBtn.onClick.AddListener(NextStage);
        selectStageBtn.onClick.AddListener(SelectStage);
        retryBtn.onClick.AddListener(RetryStage);
        gameEndBtn.onClick.AddListener(StartMenuStage);
    }

    public void NextStage()
    {
        currentStage++; // �������������� �̵�
        // ���������� �ö� �� ��� +1000 
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

        // ���� ���������� �÷��̾� ������Ʈ, �� ������Ʈ ��� ����
        if(gameObject.tag == "tower")
        {
            Destroy(gameObject); // "tower"�±� ���� ���� ���� ������Ʈ �ı�
        }

        if(gameObject.tag == "enemy")
        {
            Destroy(gameObject); // "enemy"�±� ���� ���� ���� ������Ʈ �ı�
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
            Destroy(this.gameObject); // "tower"�±� ���� ���� ���� ������Ʈ �ı�
        }

        if (gameObject.tag == "enemy")
        {
            Destroy(this.gameObject); // "enemy"�±� ���� ���� ���� ������Ʈ �ı�
        }
        Time.timeScale = 0;
        Time.timeScale = 1;
    }

    public void StartMenuStage()
    {
        //SceneManager.LoadScene(1);
    }
}

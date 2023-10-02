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
    public GameObject stageClearPanel;

    void Start()
    {
        // �ʱ� ��������
        SetStage(currentStage);
    }

    public void NextStage()
    {
        currentStage++; // �������������� �̵�
        SetStage(currentStage);
    }

    private void SetStage(int stageNum)
    {
        stageText.text = stageNum.ToString();

        // ���� ���������� �÷��̾� ������Ʈ, �� ������Ʈ ��� ����
        if(zombies != null)
        {
            Destroy(zombies);
        }

        if(Plants != null)
        {
            Destroy(Plants);
        }

        stageClearPanel.SetActive(false);
    }
}

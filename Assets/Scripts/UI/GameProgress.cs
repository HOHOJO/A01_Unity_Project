using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private Animator clearPanelAnimator;
    [SerializeField] private Animator endPanelAnimator;
    [SerializeField] private float gameTime = 70f;
   

    private bool isVictory = false;
    private bool isDefeat = false;
    private StageManager stageManager;

    private float currentTime = 0f;
    void Start()
    {
        clearPanelAnimator.gameObject.SetActive(false);
        endPanelAnimator.gameObject.SetActive(false);
        stageManager = GetComponent<StageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �ð� ������Ʈ
        if (!isVictory && !isDefeat)
        {
            currentTime += Time.deltaTime;

            // ���� �¸� ����
            if (currentTime >= gameTime)
            {                
                WinGame();
                stageManager.NextStage();
            }

        }

        // ���� �й� ����
        if (!isDefeat)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                if (enemy.transform.position.x <= -8.5f)
                {                    
                    LoseGame();                    
                    break;
                }
            }
        }
    }

    public void WinGame()
    {
        isVictory = true;
        currentTime = 0f;
        clearPanelAnimator.gameObject.SetActive(true);
        clearPanelAnimator.SetTrigger("Show");
    }

    public void LoseGame()
    {
        isDefeat = true;
        currentTime = 0f;
        endPanelAnimator.gameObject.SetActive(true);
        endPanelAnimator.SetTrigger("Show");
    }




}

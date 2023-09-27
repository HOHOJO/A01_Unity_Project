using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private Animator clearPanelAnimator;
    [SerializeField] private Animator endPanelAnimator;
    [SerializeField] private TimeController timeController;

    private bool isVictory = false;
    private bool isDefeat = false;

    void Start()
    {
        clearPanelAnimator.gameObject.SetActive(false);
        endPanelAnimator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ���ӿ��� �¸� ��
        if(isVictory)
        {
            clearPanelAnimator.gameObject.SetActive(true);
            clearPanelAnimator.SetTrigger("Show");
        }
        // ���ӿ��� �й� ��
        if(isDefeat)
        {
            endPanelAnimator.gameObject.SetActive(false);
            endPanelAnimator.SetTrigger("Show");
        }
    }

    public void WinGame()
    {
        isVictory = true;
    }

    public void LoseGame()
    {
        isDefeat = true;
    }

    // TimerController���� �ð��� ����� �� ȣ���� �޼���
    public void TimeExpired()
    {
        // �ð��� ����Ǿ��� �� ���� �¸� ó��
        if (!isVictory && !isDefeat)
        {
            isVictory = true;
            clearPanelAnimator.gameObject.SetActive(true);
            clearPanelAnimator.SetTrigger("Show");
        }
    }
}

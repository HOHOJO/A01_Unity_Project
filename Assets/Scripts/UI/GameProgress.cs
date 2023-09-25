using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    [SerializeField] private GameObject clearPanel;
    [SerializeField] private GameObject endPanel;

    private bool isVictory = false;
    private bool isDefeat = false;

    void Start()
    {
        clearPanel.SetActive(false);
        endPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 게임에서 승리 시
        if(isVictory)
        {
            clearPanel.SetActive(true);
        }
        // 게임에서 패배 시
        if(isDefeat)
        {
            endPanel.SetActive(false);
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
}

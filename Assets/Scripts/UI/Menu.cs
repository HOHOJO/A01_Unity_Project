using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    private bool isMenuActive = false;


    void Start()
    {
        menuPanel.SetActive(isMenuActive);   
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
            SetMenuActive(isMenuActive);

            // 시간을 멈추거나 다시 흘러가도록 처리
            if (isMenuActive)
            {
                Time.timeScale = 0f; 
            }
            else
            {
                Time.timeScale = 1f; 
            }
        }
    }

    
    private void SetMenuActive(bool active)
    {
        menuPanel.SetActive(active);
    }
}

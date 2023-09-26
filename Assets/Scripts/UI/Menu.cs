using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    bool activeMenu = false;

   
    void Start()
    {
        menuPanel.SetActive(activeMenu);   
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
           activeMenu = !activeMenu;
           menuPanel.SetActive(activeMenu);
           Time.timeScale = 0f;
        }
    }
}

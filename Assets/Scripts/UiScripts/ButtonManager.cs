 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private static ButtonManager instance;

    public Button settingBtn;
    public Button closeBtn;
    public GameObject menu;
    public GameObject soundMenu;
    public Button soundBtn;

    private bool isMenuAcvite = false;

    private Animator menuAnimator;


    private void Awake()
    {
        if (instance == null)
        {
            instance = null;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {


        settingBtn.onClick.AddListener(OnButtonClick);
        closeBtn.onClick.AddListener(CloseButtonClick);
        soundBtn.onClick.AddListener(SoundBtnClick);

        menu.SetActive(false);
        soundMenu.SetActive(false);
        closeBtn.gameObject.SetActive(false);

        Time.timeScale = 1f;

        menuAnimator = menu.GetComponent<Animator>();
    }

    void OnButtonClick() 
    {
        if (!isMenuAcvite)
        {
            menu.SetActive(true);
            closeBtn.gameObject.SetActive(true);

            isMenuAcvite = true;

            menuAnimator.Play("MenuPopup");
            Invoke("PauseGameTime", 1f);
  
        }
        else 
        {
            menu.SetActive(false);
            closeBtn.gameObject.SetActive(false);

            soundMenu.SetActive(false);

            isMenuAcvite = false;

            Time.timeScale = 1f;
        }
    }
    void CloseButtonClick() 
    {
        menu.SetActive(false);
        closeBtn.gameObject.SetActive(false);
        soundMenu.SetActive(false);

        isMenuAcvite = false;

        menuAnimator.Play("ClosePopup");

        Time.timeScale = 1f;
    }
    void SoundBtnClick() 
    {
        menu.SetActive(false);
        soundMenu.SetActive(true);
    }

    void PauseGameTime() 
    {
        Time.timeScale = 0f;
    }


    public static ButtonManager GetInstance()
    {
        return instance;

        //ButtonManager buttonManager = ButtonManager.GetInstance();
    }

}

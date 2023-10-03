using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private static ButtonManager instance;

    public Button settingBtn;
    public Button closeBtn;
    public Button SoundPopupBtn;
    public GameObject menu;
    public GameObject soundMenu;
    public Button soundBtn;
    public Button StageBtn;
    public Button ReplayBtn;

    private bool isMenuAcvite = false;




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
        SoundPopupBtn.onClick.AddListener(CloseSoundPopup);
        //StageBtn.onClick.AddListener(Stage);
        //ReplayBtn.onClick.AddListener(Replay);

        menu.SetActive(false);
        soundMenu.SetActive(false);
 

        Time.timeScale = 1f;


    }

    void OnButtonClick() 
    {
        if (!isMenuAcvite)
        {
            menu.SetActive(true);
          
            isMenuAcvite = true;
            Invoke("PauseGameTime", 1f);

        }
        else 
        {
            menu.SetActive(false);
            soundMenu.SetActive(false);

            isMenuAcvite = false;

            Time.timeScale = 1f;
        }
    }
    void CloseButtonClick() 
    {
        menu.SetActive(false);

        soundMenu.SetActive(false);

        isMenuAcvite = false;


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
    void CloseSoundPopup() 
    {
        soundMenu.SetActive(false);
        menu.SetActive(true);
    }
    void Stage() 
    {
        //SceneManager.LoadScene("StageScene");
    }
    void Replay() 
    {
        string reLoadScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(reLoadScene);
    }


    public static ButtonManager GetInstance()
    {
        return instance;

    }

}

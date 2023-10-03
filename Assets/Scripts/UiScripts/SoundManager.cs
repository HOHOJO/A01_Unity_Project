using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Sound 
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public GameObject BgmMixer;
    public GameObject SfxMixer;

    private static SoundManager instance;
    public static SoundManager Instance 
    {
        get { return instance; }
    }

    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmPlayer;

    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer;

    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        foreach (Sound sound in bgmSounds)
        {
            soundDictionary[sound.soundName] = sound.clip;
        }


        BgmMixer.GetComponent<Slider>().onValueChanged.AddListener(SetBgmVolume);
        SfxMixer.GetComponent<Slider>().onValueChanged.AddListener(setSfxVolume);
    }
    void Start()
    {
        PlayBGM("BackgroundMusic");

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaySE("ClickSound");
        }
    }

    public void PlayBGM(string soundName)//bgm재생
    {
        if (soundDictionary.ContainsKey(soundName))
        {
            AudioClip soundClip = soundDictionary[soundName];
            bgmPlayer.clip = soundClip;
            bgmPlayer.Play();
        }
        else
        {
            Debug.LogWarning("사운드를 찾을 수 없음: " + soundName);
        }
    }

    public void PlaySE(string _soundName) //효과음재생
    {
        for (int i = 0; i < sfxSounds.Length; i++) 
        {
            if (_soundName == sfxSounds[i].soundName) 
            {
                for (int j = 0; j < sfxPlayer.Length; j++) 
                {
                    if (!sfxPlayer[j].isPlaying) 
                    {
                        sfxPlayer[j].clip = sfxSounds[i].clip;
                        sfxPlayer[j].Play();

                        return;
                    }
                }
                return;
            }
        }
    }
    public void SetBgmVolume(float value)
    {
        bgmPlayer.volume = value;
    }
    public void setSfxVolume(float value) 
    {
        foreach (AudioSource player in sfxPlayer)
        {
            player.volume = value;
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;
using TMPro;

public class TowerObject : MonoBehaviour
{
    public TowerData data;
    private TowerManager manage;
    public int index;
    public Sprite sprite;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    private GameObject Emptybullet;
    public GameObject Me;
    public GameObject m_goHpBar;

    public bool dead = false;


    private Transform bulletSpawnPoint;
    private float timer = 0.0f;
    private int waitingTime = 2;
    private float Hit_timer = 0.0f;
    private int wating_hit = 1;

    [Header("Info")]
    public string ZombieName; //이름
    public string ZombieInfo; // 설명
    public TextMeshProUGUI LevelText;
    public GameObject levelup_popup;
    public GameObject No_levelup;

    [Header("State")]
    public float Health; // 체력
    public int Level; // 레벨(강화시 업)
    public float Intersection; // 사거리
    public float Production;// 생산력
    public float Resource; // 설치시 자원소모량
    public float LevelUp_cost;

    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        bulletSpawnPoint = this.transform.Find("BulletSpawnPoint");
        waitingTime = 2;
        timer = 0.0f;
        Hit_timer = 0.0f;
        wating_hit = 1;
        LevelUp_cost = 5;
        LevelText.text = Level.ToString();

        Emptybullet = bullet1;

        if (Production>0)
        {
            manage.Resource += Production;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Hit_timer += Time.deltaTime;
        Dead();
        if(dead){ Destroy(Me);}
        

    }

    public void Attack()
    {
        if(timer>waitingTime)
        {
            Instantiate<GameObject>(this.Emptybullet, this.bulletSpawnPoint.position, Emptybullet.transform.rotation);
            timer = 0f;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(bullet1!= null) { Attack();}
            if(Vector3.Distance(collision.transform.position, this.transform.position)<=1f)
            {
                if(Hit_timer>wating_hit)
                {
                    HitTower();
                    Hit_timer = 0f;
                }
            }
        }
    }

    public void Dead()
    {
        if(Health<=0)
        {
            dead = true;
        }
    }

    public void HitTower()
    {
        Health -= 1f;
    }

    public void ButtonClick()
    {
        if(this.Level < 3)
        {
            levelup_popup.SetActive(true);
        }
    }

    public void LevelUp()
    {
        if(manage.towerData.Production>=LevelUp_cost)
        {
            Debug.Log(this.Level);
            if (this.Level< 3)
            {
                
                switch (this.Level)
                {
                    case 1:
                        this.Emptybullet = bullet2;
                        Debug.Log("바꿈1");
                        break;

                    case 2:
                        this.Emptybullet = bullet3;
                        Debug.Log("바꿈3");
                        break;

                }

                this.Level += 1;
                Debug.Log(this.Level);
                this.Health *= 1.5f;
                this.Production *= 1.5f;
                manage.storage -= LevelUp_cost;
                this.LevelUp_cost *= 2;
                this.levelup_popup.SetActive(false);
                if(this.Level<3)
                {
                    LevelText.text = Level.ToString();
                }
                else
                {
                    LevelText.text = "Max";
                }
            }
        }
        else
        {
            No_levelup.SetActive(true);
            levelup_popup.SetActive(false);
        }
    }
}

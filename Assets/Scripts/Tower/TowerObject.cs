using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

public class TowerObject : MonoBehaviour
{
    public TowerData data;
    private TowerManager manage;
    public int index;
    public Sprite sprite;
    public GameObject bullet;
    public GameObject Me;


    public bool dead = false;


    private Transform bulletSpawnPoint;
    private float timer = 0.0f;
    private int waitingTime = 2;
    private float Hit_timer = 0.0f;
    private int wating_hit = 1;

    [Header("Info")]
    public string ZombieName; //�̸�
    public string ZombieInfo; // ����

    [Header("State")]
    public float Power;  // ���ݷ�
    public float Health; // ü��
    public int Level; // ����(��ȭ�� ��)
    public float Intersection; // ��Ÿ�
    public float Production;// �����
    public float Resource; // ��ġ�� �ڿ��Ҹ�

    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        bulletSpawnPoint = this.transform.Find("BulletSpawnPoint");
        waitingTime = 2;
        timer = 0.0f;
        Hit_timer = 0.0f;
        wating_hit = 1;

        if(Production>0)
        {
            manage.Resource += Production;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("��" + Health);
        timer += Time.deltaTime;
        Hit_timer += Time.deltaTime;
        Dead();
        if(dead){ Destroy(Me);}
        
    }

    public void Attack()
    {
        if(timer>waitingTime)
        {
            Instantiate<GameObject>(this.bullet, this.bulletSpawnPoint.position, bullet.transform.rotation);
            timer = 0f;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(bullet!= null) { Attack();}
            if(Vector3.Distance(collision.transform.position, this.transform.position)<=1f)
            {
                if(Hit_timer>wating_hit)
                {
                    Debug.Log("��" + Health);
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

    public void OnButtonClick()
    {
        
    }
}

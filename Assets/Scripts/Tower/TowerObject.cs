using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class TowerObject : MonoBehaviour
{
    public TowerData data;
    private TowerManager manage;
    public int index;
    public Sprite sprite;
    public GameObject bullet;
    private TowerSlot curSlot;
    public bool dead = false;
    private Transform bulletSpawnPoint;
    private float timer = 0.0f;
    private int waitingTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        manage = GameObject.Find("TowerManager").GetComponent<TowerManager>();
        bulletSpawnPoint = this.transform.Find("BulletSpawnPoint");
        waitingTime = 2;
        timer = 0.0f;
        if(data.Production>0)
        {
            manage.Resource += data.Production;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Dead();
        if(dead){ Destroy(this);}
    }

    public void Attack()
    {
        if(timer>waitingTime)
        {
            Instantiate<GameObject>(this.bullet, this.bulletSpawnPoint.position, Quaternion.identity);
            timer = 0f;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if(bullet!= null) { Attack();}  
        }
    }

    public void Dead()
    {
        if(data.Health<=0)
        {
            dead = true;
        }
    }

    public void OnButtonClick()
    {
        
    }
}

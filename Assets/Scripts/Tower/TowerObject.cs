using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class TowerObject : MonoBehaviour
{
    public TowerData data;
    public int index;
    public Sprite sprite;
    public GameObject bullet;
    private TowerSlot curSlot;
    public bool dead;
    private Transform bulletSpawnPoint;
    private List<GameObject> coll = new List<GameObject>();
    private float timer = 0.0f;
    private int waitingTime = 2;

    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnPoint = this.transform.Find("BulletSpawnPoint");
        waitingTime = 2;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
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

    public void Production()
    {
        if (bullet == null) { }
    }

    public void Dead()
    {

    }

    public void OnButtonClick()
    {
        
    }
}

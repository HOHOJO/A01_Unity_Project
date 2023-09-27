using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Hp = 10f;
    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range( 17f, 17f);
        float y = Random.Range(-6f, 0.6f);
        transform.position = new Vector3(x, y, 0);
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(-0.01f, 0, 0);

        if( Hp <= 0)
        {
            SpawnManager._instance.enemyCount++;
            SpawnManager._instance.isSpawn[int.Parse(transform.parent.name) - 1] = false;
            Destroy(this.gameObject);
        }
        
    }
    public void TakeDamage(int damage)
    {
        Hp = Hp - damage;
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Ball")
        {
            Hp -= 1f;
            Destroy(coll.gameObject);
           
        }
    }


}

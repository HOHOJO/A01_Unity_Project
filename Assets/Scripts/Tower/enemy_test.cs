using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_test : MonoBehaviour
{
    public float speed;
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = speed * Time.deltaTime * -1;

        transform.Translate(moveX, 0, 0);
        if(hp<=0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch(collision.tag)
        {
            case "Bullet1":
                hp -= 3f;
                break;

            case "Bullet2":
                hp -= 5f;
                break;

            case "Bullet3":
                hp -= 10f;
                break;

            default:
                if (collision.tag == "Tower")
                {
                    if (Vector3.Distance(collision.transform.position, this.transform.position) <= 1f)
                    {

                        float moveX = speed * Time.deltaTime * 1;

                        transform.Translate(moveX, 0, 0);
                    }
                }
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject myBullet;
    public float speed = 1f;
    public float dmg = 3f;
    //[SerializeField][Range(1f, 100f)] float rotate = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // �Ѿ��� ���� ���󰡸� ���� ���ֱ�
        if (this.transform.position.x > 7)
        {
            Destroy(this.gameObject);
        }
        //this.transform.Rotate(0, 0, rotate *Time.deltaTime);
        float moveX = speed * Time.deltaTime;
        transform.Translate(0,moveX, 0);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(myBullet);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �Ѿ��� ���� ���󰡸� ���� ���ֱ�
        if (this.transform.position.x > 3)
        {
            Destroy(this.gameObject);
        }
        float moveX = speed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);
    }
}

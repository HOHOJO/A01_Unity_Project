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
        // 총알이 많이 날라가면 삭제 해주기
        if (this.transform.position.x > 3)
        {
            Destroy(this.gameObject);
        }
        float moveX = speed * Time.deltaTime;
        transform.Translate(moveX, 0, 0);
    }
}

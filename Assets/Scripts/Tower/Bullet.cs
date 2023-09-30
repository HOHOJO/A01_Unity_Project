using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    //[SerializeField][Range(1f, 100f)] float rotate = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 총알이 많이 날라가면 삭제 해주기
        if (this.transform.position.x > 7)
        {
            Destroy(this.gameObject);
        }
        //this.transform.Rotate(0, 0, rotate *Time.deltaTime);
        float moveX = speed * Time.deltaTime;
        transform.Translate(0,moveX, 0);
    }
}

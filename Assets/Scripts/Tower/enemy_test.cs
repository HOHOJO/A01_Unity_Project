using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_test : MonoBehaviour
{
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = speed * Time.deltaTime * -1;

        transform.Translate(moveX, 0, 0);
    }
}

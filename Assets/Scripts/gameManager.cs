using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject Ball;
    public GameObject player;
    public GameObject player1;
    public GameObject player2;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("makeBall", 0.2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void makeBall()
    {
        float x = player.transform.position.x + 2.0f;
        float y = player.transform.position.y;
        Instantiate(Ball, new Vector3(x, y, 0), Quaternion.identity);
    }
}

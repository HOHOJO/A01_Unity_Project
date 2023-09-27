using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int maxCount;
    public int enemyCount;
    public float spwanTime = 3f;
    public float curTime;
    public Transform[] spawnPoints;
    public bool[] isSpawn;
    public GameObject enemy;
    public GameObject enemy1;
    public GameObject enemy2;

    public static SpawnManager _instance;
    private void Start()
    {
        isSpawn = new bool[spawnPoints.Length];
        for (int i = 0; i < isSpawn.Length; i++)
        {
            isSpawn[i] = false;
        }
        _instance = this;
    }
    private void Update()
    {
        if (curTime >= spwanTime && enemyCount < maxCount)
        {
            int x = Random.Range(0, spawnPoints.Length);
            if (!isSpawn[x])
            SpawnEnemy(x);
        }
        curTime += Time.deltaTime;
    }
    
    private void SpawnEnemy(int ranNum)
    {
        curTime = 0;
        enemyCount++;
        Instantiate(enemy,spawnPoints[ranNum]);
        isSpawn[ranNum] = true;
       
    }

}


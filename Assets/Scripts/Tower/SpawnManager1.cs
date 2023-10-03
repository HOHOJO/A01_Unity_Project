using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnManager1 : MonoBehaviour
{
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;

    public GameObject Enemy;

    public static SpawnManager1 instance; // 매니저는 단 하나만 존재한다.
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Enemy, SpawnPoint1.transform.position, Quaternion.identity);

        Invoke("spawn1", 10f);
        Invoke("spawn2", 20f);
        Invoke("spawn3", 30f);
        Invoke("spawn4", 40f);
        Invoke("spawn5", 50f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void spawn1()
    {
        Instantiate(Enemy, SpawnPoint1.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint2.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint3.transform.position, Quaternion.identity);
    }

    public void spawn2()
    {
        Instantiate(Enemy, SpawnPoint1.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint2.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint3.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint4.transform.position, Quaternion.identity);
    }

    public void spawn3()
    {
        Instantiate(Enemy, SpawnPoint1.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint2.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint3.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint4.transform.position, Quaternion.identity);
    }

    public void spawn4()
    {
        Instantiate(Enemy, SpawnPoint1.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint2.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint3.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint4.transform.position, Quaternion.identity);
    }

    public void spawn5()
    {
        Instantiate(Enemy, SpawnPoint1.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint2.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint3.transform.position, Quaternion.identity);
        Instantiate(Enemy, SpawnPoint4.transform.position, Quaternion.identity);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    public float storage = 0f;
    public float Resource = 3f;
    public float Resource_time = 0f;
    public TextMeshProUGUI Text;
    private int waitingTime = 10;
    private List<TowerObject> Towers = new List<TowerObject>();
    private int Index = 0;

    public static TowerManager instance;
    // Start is called before the first frame update
    void Start()
    {
        Index = 0;
        Debug.Log(Resource);
    }

    // Update is called once per frame
    void Update()
    {
        Resource_time += Time.deltaTime;
        if(Resource_time>waitingTime)
        {
            Production();
            Resource_time = 0f;
        }

    }

    public void Production()
    {
        storage += Resource;
        Text.text = storage.ToString();
    }

    public void IndexUp(TowerObject gameObject)
    {
        gameObject.index = Index;
        Index++;
        Towers.Add(gameObject);
        Resource += gameObject.data.Production;
    }
}

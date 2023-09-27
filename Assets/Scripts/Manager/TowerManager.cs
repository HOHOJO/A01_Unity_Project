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

    [SerializeField]
    private Camera main;
    private Vector2 pos;
    private RaycastHit2D hit;

    [SerializeField]
    public GameObject TowerPrefab1;
    public GameObject TowerPrefab2;
    public GameObject TowerPrefab3;
    public GameObject TowerPrefab4;
    private GameObject EmptyTower;
    private bool Mouse;

    public static TowerManager instance;

    private void Awake()
    {
        main = Camera.main;
        Mouse=true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Index = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = main.ScreenToWorldPoint(Input.mousePosition);
            if (Mouse)
            {
                Debug.Log("여기 옴");
                hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
                if (hit.collider!=null)
                {
                    Debug.Log("여기 들어옴");
                    if (hit.transform.CompareTag("Tower"))
                    {
                        EmptyTower = TowerPrefab1;
                        Mouse = false;
                    }
                }
            }
            else
            {
                if(EmptyTower!=null)
                {
                    Debug.Log("설치할거임");
                    Instantiate(EmptyTower, pos, Quaternion.identity) ;
                    Mouse = true;
                }
            }

        }

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
        //Text.text = storage.ToString();
    }

    public void IndexUp(TowerObject gameObject)
    {
        gameObject.index = Index;
        Index++;
        Towers.Add(gameObject);
        Resource += gameObject.data.Production;
    }
}

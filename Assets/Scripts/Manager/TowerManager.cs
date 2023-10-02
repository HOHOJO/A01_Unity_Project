using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    public float storage = 0f;  // 창고
    public float Resource = 3f;  //생산력
    public float Resource_time = 0f; // 
    public TextMeshProUGUI Text; // 창고 표시 텍스트
    private int waitingTime = 10; // 생산시간(10초에 한번씩)
    private List<TowerObject> Towers = new List<TowerObject>(); // 타워 리스트
    private int Index = 0;

    [SerializeField]
    private Camera main; // 카메라
    private Vector2 pos; // 위치
    private RaycastHit2D hit; // 위치 파악하기용 레이저

    [SerializeField]
    public GameObject TowerPrefab1; // 타워 1234
    public GameObject TowerPrefab2;
    public GameObject TowerPrefab3;
    public GameObject TowerPrefab4;
    private GameObject EmptyTower; // 설치용 빈 타워
    private bool Mouse; // 마우스 잠구기 용

    public static TowerManager instance; // 매니저는 단 하나만 존재한다.

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
        if(Input.GetMouseButtonDown(0)) // 마우스 입력 반응
        {
            Vector2 pos = main.ScreenToWorldPoint(Input.mousePosition); // 글로번 위치를 가져온다.
            
            if(!Mouse) // 타워가 선택되어 마우스가 일부 잠겨있는지 파악, 일부 잠겨있어야 한다.
            {
                hit = Physics2D.Raycast(pos, Vector2.zero, 0f);// 레이저를 발사해 해당 위치에 뭐가 있는지 파악
                if (hit.collider != null)// 아무것도 없으면 무시한다.
                {
                    if (hit.transform.CompareTag("Tile")) // 해당 위치에 오브젝트의 태그가 타일인지 보기
                    {
                        //BuildTower();
                        storage -= 3;
                        Instantiate(EmptyTower, pos, Quaternion.identity);  // 설치
                        Mouse = true; // 마우스 잠금 풀기
                    }
                }
                else
                {
                    Debug.Log("설치위치 파악실패");
                }
            }
        }

        // 생산력에 따라 생산
        Resource_time += Time.deltaTime;
        if(Resource_time>waitingTime)
        {
            Production();
            Resource_time = 0f;
        }

    }

    public void Production() // 생산
    {
        storage += Resource;
        //Text.text = storage.ToString();
    }

    public void IndexUp(TowerObject gameObject) // 타워 인덱스 지정(사용안됨)
    {
        gameObject.index = Index;
        Index++;
        Towers.Add(gameObject);
        Resource += gameObject.data.Production;
    }

    public void SelectTower(int i) // 포탑 선택
    {
        Mouse = true;
        if(storage>=3) // 자원 3이 있나
        {
            if (Mouse)
            {
                switch (i)
                {
                    case 0:
                        EmptyTower = TowerPrefab1;
                        Mouse = false; // 마우스 잠구기
                        Debug.Log("선택1");
                        Debug.Log(Mouse);
                        break;

                    case 1:
                        EmptyTower = TowerPrefab2;
                        Mouse = false;
                        Debug.Log("선택2");
                        Debug.Log(Mouse);
                        break;

                    case 2:

                        break;

                    case 3:

                        break;
                }
            }
        }
        else
        {
            Debug.Log("자원부족");
        }
    }

    public void BuildTower()
    {
        Instantiate(EmptyTower, pos, Quaternion.identity);
    }
}

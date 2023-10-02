using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [SerializeField]
    public float storage = 0f;  // â��
    public float Resource = 3f;  //�����
    public float Resource_time = 0f; // 
    public TextMeshProUGUI Text; // â�� ǥ�� �ؽ�Ʈ
    private int waitingTime = 10; // ����ð�(10�ʿ� �ѹ���)
    private List<TowerObject> Towers = new List<TowerObject>(); // Ÿ�� ����Ʈ
    private int Index = 0;

    [SerializeField]
    private Camera main; // ī�޶�
    private Vector2 pos; // ��ġ
    private RaycastHit2D hit; // ��ġ �ľ��ϱ�� ������

    [SerializeField]
    public GameObject TowerPrefab1; // Ÿ�� 1234
    public GameObject TowerPrefab2;
    public GameObject TowerPrefab3;
    public GameObject TowerPrefab4;
    private GameObject EmptyTower; // ��ġ�� �� Ÿ��
    private bool Mouse; // ���콺 �ᱸ�� ��

    public static TowerManager instance; // �Ŵ����� �� �ϳ��� �����Ѵ�.

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
        if(Input.GetMouseButtonDown(0)) // ���콺 �Է� ����
        {
            Vector2 pos = main.ScreenToWorldPoint(Input.mousePosition); // �۷ι� ��ġ�� �����´�.
            
            if(!Mouse) // Ÿ���� ���õǾ� ���콺�� �Ϻ� ����ִ��� �ľ�, �Ϻ� ����־�� �Ѵ�.
            {
                hit = Physics2D.Raycast(pos, Vector2.zero, 0f);// �������� �߻��� �ش� ��ġ�� ���� �ִ��� �ľ�
                if (hit.collider != null)// �ƹ��͵� ������ �����Ѵ�.
                {
                    if (hit.transform.CompareTag("Tile")) // �ش� ��ġ�� ������Ʈ�� �±װ� Ÿ������ ����
                    {
                        //BuildTower();
                        storage -= 3;
                        Instantiate(EmptyTower, pos, Quaternion.identity);  // ��ġ
                        Mouse = true; // ���콺 ��� Ǯ��
                    }
                }
                else
                {
                    Debug.Log("��ġ��ġ �ľǽ���");
                }
            }
        }

        // ����¿� ���� ����
        Resource_time += Time.deltaTime;
        if(Resource_time>waitingTime)
        {
            Production();
            Resource_time = 0f;
        }

    }

    public void Production() // ����
    {
        storage += Resource;
        //Text.text = storage.ToString();
    }

    public void IndexUp(TowerObject gameObject) // Ÿ�� �ε��� ����(���ȵ�)
    {
        gameObject.index = Index;
        Index++;
        Towers.Add(gameObject);
        Resource += gameObject.data.Production;
    }

    public void SelectTower(int i) // ��ž ����
    {
        Mouse = true;
        if(storage>=3) // �ڿ� 3�� �ֳ�
        {
            if (Mouse)
            {
                switch (i)
                {
                    case 0:
                        EmptyTower = TowerPrefab1;
                        Mouse = false; // ���콺 �ᱸ��
                        Debug.Log("����1");
                        Debug.Log(Mouse);
                        break;

                    case 1:
                        EmptyTower = TowerPrefab2;
                        Mouse = false;
                        Debug.Log("����2");
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
            Debug.Log("�ڿ�����");
        }
    }

    public void BuildTower()
    {
        Instantiate(EmptyTower, pos, Quaternion.identity);
    }
}

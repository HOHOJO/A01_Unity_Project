using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_test2 : MonoBehaviour
{
    
    [SerializeField]
    private int gold = 10; // �� ���� �� ȹ�� ������ ���

    // ���� ��ǥ������ �����ؼ� ������ ������ ��� ȹ��x 
    private void EnemyToGoal()
    {
        gold = 0;
    }
   
}

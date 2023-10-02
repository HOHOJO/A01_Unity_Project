using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy_test2 : MonoBehaviour
{
    
    [SerializeField]
    private int gold = 10; // 적 제거 시 획득 가능한 골드

    // 적이 목표지점에 도달해서 제거할 때에는 골드 획득x 
    private void EnemyToGoal()
    {
        gold = 0;
    }
   
}

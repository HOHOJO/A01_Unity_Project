using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner_Test : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private int towerBuildGold = 100;  // 타워 건설 시 사용되는 골드
    [SerializeField]
    private PlayerGold playerGold; // 타워 건설 시 플레이어 골드 감소

    public void SpawnTower(Transform tileTransform)
    {
        // 타워 건설 가능여부 확인
        // 타워를 건설할 만큼의 돈이 없으면 타워 건설x
        if(towerBuildGold > playerGold.CurrentGold)
        {
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

    }
}


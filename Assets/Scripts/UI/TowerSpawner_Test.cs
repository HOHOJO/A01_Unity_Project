using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner_Test : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;
    [SerializeField]
    private int towerBuildGold = 100;  // Ÿ�� �Ǽ� �� ���Ǵ� ���
    [SerializeField]
    private PlayerGold playerGold; // Ÿ�� �Ǽ� �� �÷��̾� ��� ����

    public void SpawnTower(Transform tileTransform)
    {
        // Ÿ�� �Ǽ� ���ɿ��� Ȯ��
        // Ÿ���� �Ǽ��� ��ŭ�� ���� ������ Ÿ�� �Ǽ�x
        if(towerBuildGold > playerGold.CurrentGold)
        {
            return;
        }

        Tile tile = tileTransform.GetComponent<Tile>();

    }
}


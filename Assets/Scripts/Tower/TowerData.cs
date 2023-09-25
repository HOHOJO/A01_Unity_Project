using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ZombieType
{
    Attacker,
    Defender,
    Producer
}


[System.Serializable]
public class ZombieDataConsumable
{
    public ZombieType type;
    public float value;
}

[CreateAssetMenu(fileName = "TowerData", menuName = "Scriptable Object/TowerData")]

public class TowerData : ScriptableObject
{
    [Header("Info")]
    public string ZombieName; //�̸�
    public string ZombieInfo; // ����
    public ZombieType type; // Ÿ��
    public Sprite sprite; // �̹���

    [Header("State")]
    public float Power;  // ���ݷ�
    public float Health; // ü��
    public int Level; // ����(��ȭ�� ��)
    public float Intersection; // ��Ÿ�
}

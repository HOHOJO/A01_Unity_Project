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
    public string ZombieName; //이름
    public string ZombieInfo; // 설명
    public ZombieType type; // 타입
    public Sprite sprite; // 이미지

    [Header("State")]
    public float Power;  // 공격력
    public float Health; // 체력
    public int Level; // 레벨(강화시 업)
    public float Intersection; // 사거리
}

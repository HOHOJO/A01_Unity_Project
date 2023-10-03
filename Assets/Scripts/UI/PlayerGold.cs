using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGold : MonoBehaviour
{
    [SerializeField]
    private int currentGold = 1000;

    public int CurrentGold
    {
        get => currentGold;
        set => currentGold = Mathf.Max(0, value);
    }
}

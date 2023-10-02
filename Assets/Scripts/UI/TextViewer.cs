using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textPlayerGold;
    [SerializeField] private PlayerGold playerGold;

    private void Update()
    {
        textPlayerGold.text = playerGold.CurrentGold.ToString();
    }

}

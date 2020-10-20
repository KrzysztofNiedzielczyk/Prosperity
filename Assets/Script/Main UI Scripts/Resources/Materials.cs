using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Materials : MonoBehaviour
{
    private int _mineralsAmount;
    public TextMeshProUGUI amount;

    void Update()
    {
        _mineralsAmount = GameManager.Instance.GetMaterialsAmount();
        amount.text = _mineralsAmount.ToString();
    }
}

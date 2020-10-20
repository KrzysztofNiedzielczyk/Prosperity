using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private int goldAmount;
    public TextMeshProUGUI amount;

    // Update is called once per frame
    void Update()
    {
        goldAmount = GameManager.Instance.GetGoldAmount();
        amount.text = goldAmount.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gems : MonoBehaviour
{
    private int gemsAmount;
    public TextMeshProUGUI amount;

    // Update is called once per frame
    void Update()
    {
        gemsAmount = GameManager.Instance.GetGemsAmount();
        amount.text = gemsAmount.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleEnemyAmount : MonoBehaviour
{
    public BattleEnemySlotTemplate battleEnemySlotTemplate;
    public TextMeshProUGUI amountTMP;

    void Update()
    {
        amountTMP.text = battleEnemySlotTemplate.unitAmount.ToString();
    }
}

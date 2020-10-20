using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleUnitAmount : MonoBehaviour
{
    public BattleUnitSlotTemplate battleUnitSlotTemplate;
    public TextMeshProUGUI amountTMP;

    void Update()
    {
        amountTMP.text = battleUnitSlotTemplate.unitAmount.ToString();
    }
}

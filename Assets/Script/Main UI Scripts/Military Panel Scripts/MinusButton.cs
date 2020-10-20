using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinusButton : MonoBehaviour
{
    public UnitSlotTemplate unitSlotTemplate;
    public UnitsCostPanel unitsCostPanel;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(SubtractCost);
    }

    void SubtractCost()
    {
        unitsCostPanel.SubtractCost(unitSlotTemplate.materialsCost, unitSlotTemplate.goldCost, unitSlotTemplate.gemsCost, unitSlotTemplate.populationCost);
    }
}

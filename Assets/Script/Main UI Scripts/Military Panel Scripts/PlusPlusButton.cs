using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusPlusButton : MonoBehaviour
{
    public UnitSlotTemplate unitSlotTemplate;
    public UnitsCostPanel unitsCostPanel;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(AddCost);
    }

    void AddCost()
    {
        unitsCostPanel.AddCost(unitSlotTemplate.materialsCost*10, unitSlotTemplate.goldCost*10, unitSlotTemplate.gemsCost*10, unitSlotTemplate.populationCost*10);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlusButton : MonoBehaviour
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
        unitsCostPanel.AddCost(unitSlotTemplate.materialsCost, unitSlotTemplate.goldCost, unitSlotTemplate.gemsCost, unitSlotTemplate.populationCost);
    }
}

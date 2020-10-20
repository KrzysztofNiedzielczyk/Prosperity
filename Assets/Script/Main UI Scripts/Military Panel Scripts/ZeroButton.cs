using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZeroButton : MonoBehaviour
{
    public UnitSlotTemplate unitSlotTemplate;
    public UnitsCostPanel unitsCostPanel;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ZeroCost);
    }

    void ZeroCost()
    {
        unitsCostPanel.SubtractCost(unitSlotTemplate.currentMaterialsCost, unitSlotTemplate.currentGoldCost, unitSlotTemplate.currentGemsCost, unitSlotTemplate.currentPopulationCost);
    }
}

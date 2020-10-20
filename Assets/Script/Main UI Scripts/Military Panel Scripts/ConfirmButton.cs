using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmButton : MonoBehaviour
{
    public UnitsCostPanel unitsCostPanel;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(AddUnitsToFriendlyTroops);
    }

    void AddUnitsToFriendlyTroops()
    {
        for (int i = 0; i < unitsCostPanel.troopsToBuy.Count; i++)
        {
            var unit = unitsCostPanel.troopsToBuy[i];
            FriendlyTroops.Instance.AddUnit(unit.unitID, unit.unitCount);
        }
    }
}

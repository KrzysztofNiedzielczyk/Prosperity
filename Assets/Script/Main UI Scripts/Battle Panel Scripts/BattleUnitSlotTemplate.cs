using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitSlotTemplate : MonoBehaviour
{
    public int unitID;
    public int unitAmount;

    private void Update()
    {
        unitAmount = FriendlyTroops.Instance.friendlyTroops[unitID-1].unitCount;

        Deactivate();
    }

    void Deactivate()
    {
        if (unitAmount <= 0)
            gameObject.SetActive(false);
    }
}

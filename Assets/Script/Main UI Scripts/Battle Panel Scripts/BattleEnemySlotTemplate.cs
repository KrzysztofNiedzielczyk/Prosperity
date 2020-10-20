using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemySlotTemplate : MonoBehaviour
{
    public int unitID;
    public int unitAmount;

    private void Update()
    {
        unitAmount = EnemyTroops.Instance.enemyUnits[unitID - 1].unitCount;

        Deactivate();
    }

    void Deactivate()
    {
        if (unitAmount <= 0)
            gameObject.SetActive(false);
    }
}
